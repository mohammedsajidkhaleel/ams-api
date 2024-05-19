using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.domain.Abstractions;
using ams.domain.ItemReceipts;
using Dapper;

namespace ams.application.ItemReceipts.EditItemReceipt;
internal sealed class EditItemReceiptCommandHandler : ICommandHandler<EditItemReceiptCommand, Guid>
{
    private readonly IItemReceiptRepository _itemReceiptRepository;
    private readonly IItemReceiptDetailRepository _itemReceiptDetailRepository;
    private readonly IUnitOfWork _unitOfWork;
    public EditItemReceiptCommandHandler(
           IItemReceiptRepository itemReceiptRepository,
        IUnitOfWork unitOfWork,
        IItemReceiptDetailRepository itemReceiptDetailRepository)
    {
        _itemReceiptRepository = itemReceiptRepository;
        _unitOfWork = unitOfWork;
        _itemReceiptDetailRepository = itemReceiptDetailRepository;
    }
    public async Task<Result<Guid>> Handle(
        EditItemReceiptCommand request,
        CancellationToken cancellationToken)
    {
        var itemReceipt = await _itemReceiptRepository.GetByIdAsync(request.ItemReceiptId);
        if (itemReceipt == null)
            return null;
        foreach (var detail in itemReceipt.Details)
            _itemReceiptDetailRepository.Remove(detail);
        //itemReceipt.Details.Clear();

        var itemDetails = new List<ItemReceiptDetail>();
        foreach (var irdr in request.ItemDetails)
        {
            var itemSerialNumbers = new List<ItemReceiptItemSerialNumber>();
            foreach (var itemSerialNumber in irdr.SerialNumbers)
                itemSerialNumbers.Add(new ItemReceiptItemSerialNumber(itemSerialNumber));
            var id = ItemReceiptDetail.Create(irdr.ItemId, irdr.Quantity, irdr.Description, itemSerialNumbers);
            itemDetails.Add(id);
        }

        ItemReceipt.Edit(
            itemReceipt,
            request.PONumber,
            request.Description,
            itemDetails
        );
        await _unitOfWork.SaveChangesAsync();
        return itemReceipt.Id;
    }
}

