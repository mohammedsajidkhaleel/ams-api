using ams.application.Abstractions.Messaging;
using ams.domain.Abstractions;
using ams.domain.Assets;
using ams.domain.ItemReceipts;
using ams.domain.Shared;

namespace ams.application.ItemReceipts.ConvertToAsset;

internal sealed class ConvertToAssetCommandHandler
    : ICommandHandler<ConvertToAssetCommand, bool>
{
    private readonly IItemReceiptRepository _itemReceiptRepository;
    private readonly IAssetRepository _assetRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ConvertToAssetCommandHandler(IItemReceiptRepository itemReceiptRepository, IUnitOfWork unitOfWork, IAssetRepository assetRepository)
    {
        _itemReceiptRepository = itemReceiptRepository;
        _unitOfWork = unitOfWork;
        _assetRepository = assetRepository;
    }

    public async Task<Result<bool>> Handle(ConvertToAssetCommand request, CancellationToken cancellationToken)
    {
        var itemReceipt = await _itemReceiptRepository.GetByIdAsync(request.ItemReceiptId);
        if (itemReceipt == null)
            return null;
        if (itemReceipt.Status != ItemReceiptStatus.New)
            return null;

        foreach (var asset in request.Assets)
        {
            var detail = itemReceipt.Details.FirstOrDefault(i => i.ItemId == asset.ItemId);
            var serialNumber = detail.SerialNumbers.FirstOrDefault(i => i.Id == asset.ItemReceiptSerialNumberId).SerialNumber;

            var newAsset = Asset.CreateAsset(
                new AssetCode(asset.AssetCode),
                new AssetName(asset.AssetName),
                new SerialNumber(serialNumber),
                asset?.AssignedTo,
                null,
                new AssetDescription(""),
                asset.ItemId,
                new PONumber(itemReceipt.PONumber),
                asset?.AssignedTo == null ? AssetStatus.Issued : AssetStatus.InStock
                );
            _assetRepository.Add(newAsset);
        }
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
