using CarRepairShop.Application.Interfaces;
using CarRepairShop.Domain.Aggregates.RepairOrderAggregate;
using CarRepairShop.Domain.Interfaces;
using CarRepairShop.Domain.ValueObjects;
using MediatR;

namespace CarRepairShop.Application.Commands.RepairOrder;

public class UpdateRepairOrderCommandHandler : IRequestHandler<UpdateRepairOrderCommand>
{
    private readonly IGenericRepository<RepairOrderEntity> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRepairOrderCommandHandler(IGenericRepository<RepairOrderEntity> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateRepairOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetByIdAsync(request.RepairOrder.Id, cancellationToken);
        if (order == null) throw new Exception("Repair order not found");

        if (request.RepairOrder.MechanicId.HasValue)
            order.AssignMechanic(request.RepairOrder.MechanicId.Value);

        if (!string.IsNullOrEmpty(request.RepairOrder.Description))
            order.UpdateDescription(request.RepairOrder.Description);

        var repairCost=new Money(request.RepairOrder.RepairCost, request.RepairOrder.RepairCostCurrency);
        order.UpdateRepairCost(repairCost);

        if (request.RepairOrder.IsCompleted.HasValue && request.RepairOrder.IsCompleted.Value)
            order.MarkCompleted();

        order.MarkAsUpdated();
        _repository.Update(order);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}