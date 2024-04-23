using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.domain.Abstractions;
using ams.domain.ItemReceipts;
using Dapper;

namespace ams.application.ItemReceipts.CreateItemReceipt;
internal sealed class CreateItemReceiptCommandHandler : ICommandHandler<CreateItemReceiptCommand, Guid>
{
    private readonly IItemReceiptRepository _itemReceiptRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    public CreateItemReceiptCommandHandler(
           IItemReceiptRepository itemReceiptRepository,
        IUnitOfWork unitOfWork,
        ISqlConnectionFactory connection)
    {
        _itemReceiptRepository = itemReceiptRepository;
        _unitOfWork = unitOfWork;
        _sqlConnectionFactory = connection;
    }
    public async Task<Result<Guid>> Handle(
        CreateItemReceiptCommand request,
        CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        var query = """
            SELECT cast(COALESCE(MAX(ITEM_RECEIPT_NUMBER),'10000000') as int) + 1
            FROM ITEM_RECEIPTS
            """;

        var itemReceiptNumber = await connection.ExecuteScalarAsync<string>(query);
        var itemReceipt = ItemReceipt.Create(
            request.pONumber,
            itemReceiptNumber,
            request.description,
            ItemReceiptStatus.New,
            request.itemDetails
         );
        _itemReceiptRepository.Add(itemReceipt);
        await _unitOfWork.SaveChangesAsync();
        return itemReceipt.Id;
    }
}

