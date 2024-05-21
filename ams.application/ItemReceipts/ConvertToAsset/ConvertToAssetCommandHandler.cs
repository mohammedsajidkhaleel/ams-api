using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.application.ItemReceipts.GetItemReceipt;
using ams.domain.Abstractions;
using ams.domain.Assets;
using ams.domain.ItemReceipts;
using ams.domain.Shared;
using Dapper;

namespace ams.application.ItemReceipts.ConvertToAsset;

internal sealed class ConvertToAssetCommandHandler
    : ICommandHandler<ConvertToAssetCommand, bool>
{
    private readonly IItemReceiptRepository _itemReceiptRepository;
    private readonly IAssetRepository _assetRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    public ConvertToAssetCommandHandler(IItemReceiptRepository itemReceiptRepository, IUnitOfWork unitOfWork, IAssetRepository assetRepository, ISqlConnectionFactory sqlConnectionFactory)
    {
        _itemReceiptRepository = itemReceiptRepository;
        _unitOfWork = unitOfWork;
        _assetRepository = assetRepository;
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<bool>> Handle(ConvertToAssetCommand request, CancellationToken cancellationToken)
    {
        var itemReceipt = await _itemReceiptRepository.GetByIdAsync(request.ItemReceiptId);
        if (itemReceipt == null)
            return null;
        if (itemReceipt.Status != ItemReceiptStatus.New)
            return null;

        var query = """
                        SELECT IRS.ID AS ITEMRECEIPTSERIALID,
            	IRS.SERIAL_NUMBER AS SERIALNUMBER,
            	IRD.ITEM_ID AS ITEMID
            FROM ITEM_RECEIPT_ITEM_SERIAL_NUMBERS IRS
            INNER JOIN ITEM_RECEIPT_DETAILS IRD ON IRD.ID = IRS.ITEM_RECEIPT_DETAIL_ID
            WHERE IRS.IS_DELETED = 'FALSE'
            AND IRD.ITEM_RECEIPT_ID = @ItemReceiptId;
            """;
        using var connection = _sqlConnectionFactory.CreateConnection();
        var result = await connection
            .QueryAsync<ItemReceiptSerialNumberResponse>(
            query,
            new
            {
                request.ItemReceiptId
            }
            );
        var details = result.ToList();
        if (details != null && details.Count > 0)
        {
            bool saved = false;
            foreach (var asset in request.Assets)
            {
                var detail = details.FirstOrDefault(i => i.ItemReceiptSerialId == asset.ItemReceiptSerialNumberId);
                if (detail != null)
                {
                    var newAsset = Asset.CreateAsset(
                        new AssetCode(asset.AssetCode),
                        new AssetName(asset.AssetName),
                        new SerialNumber(detail.SerialNumber),
                        asset?.AssignedTo,
                        null,
                        new AssetDescription(""),
                        detail.ItemId,
                        new PONumber(itemReceipt.PONumber),
                        asset?.AssignedTo == null ? AssetStatus.Issued : AssetStatus.InStock
                        );
                    _assetRepository.Add(newAsset);
                    saved = true;
                }
            }
            if (saved)
                ItemReceipt.SetStatus(itemReceipt, ItemReceiptStatus.ConvertedToAsset);
            await _unitOfWork.SaveChangesAsync();
        }
        return true;
    }
}
