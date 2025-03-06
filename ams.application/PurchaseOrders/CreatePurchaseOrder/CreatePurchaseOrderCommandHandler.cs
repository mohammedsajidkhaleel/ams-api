using ams.application.Abstractions.Messaging;
using ams.domain.Abstractions;
using ams.domain.Employees;
using ams.domain.PurchaseOrders;
using ams.domain.Shared;

namespace ams.application.PurchaseOrders.CreatePurchaseOrder;

public sealed class CreatePurchaseOrderCommandHandler
    : ICommandHandler<CreatePurchaseOrderCommand, Guid>
{
    private readonly IPurchaseOrderRepository _purchaseOrderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePurchaseOrderCommandHandler(IPurchaseOrderRepository purchaseOrderRepository, IUnitOfWork unitOfWork)
    {
        _purchaseOrderRepository = purchaseOrderRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreatePurchaseOrderCommand request, CancellationToken cancellationToken)
    {
        List<PurchaseOrderItem> purchaseOrderItems = new();
        foreach (var item in request.Items)
        {
            purchaseOrderItems.Add(PurchaseOrderItem.CreatePurchaseOrderItem(
                item.ItemId,
                item.Quantity));
        }
        var purchaseOrder = PurchaseOrder.CreatePurchaseOrder(
            new PONumber(request.PoNumber),
            request.PurchaseDate,
            request.CreatedBy,
            request.CreatedUserName,
            purchaseOrderItems
            );
        _purchaseOrderRepository.Add(purchaseOrder);
        await _unitOfWork.SaveChangesAsync();
        return purchaseOrder.Id;
    }
}
