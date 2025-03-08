using ams.application.Abstractions.Messaging;
using ams.domain.Abstractions;
using ams.domain.PurchaseOrders;

namespace ams.application.PurchaseOrders.DeletePurchaseOrder;
internal sealed class DeletePurchaseOrderCommandHandler
    : ICommandHandler<DeletePurchaseOrderCommand, Guid>
{
    private readonly IPurchaseOrderRepository _purchaseOrderRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeletePurchaseOrderCommandHandler(IPurchaseOrderRepository purchaseOrderRepository, IUnitOfWork unitOfWork)
    {
        _purchaseOrderRepository = purchaseOrderRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(
        DeletePurchaseOrderCommand request,
        CancellationToken cancellationToken)
    {
       var purchaseOrder = await _purchaseOrderRepository.GetByIdAsync(request.PurchaseOrderId,cancellationToken);
        if(purchaseOrder != null) {
            _purchaseOrderRepository.Remove(purchaseOrder);
            await _unitOfWork.SaveChangesAsync();
        }
        return null;
    }
}

