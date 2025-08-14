using CarRepairShop.Application.Interfaces;
using CarRepairShop.Domain.Entities;
using CarRepairShop.Domain.Interfaces;
using CarRepairShop.Domain.ValueObjects;
using MediatR;

namespace CarRepairShop.Application.Commands.RepairOrder;

public class CreateRepairOrderCommandHandler : IRequestHandler<CreateRepairOrderCommand,Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<RepairOrderEntity> _repairOrderRepository;

    public CreateRepairOrderCommandHandler(IUnitOfWork unitOfWork,IGenericRepository<RepairOrderEntity> repairOrderRepository)
    {
        _unitOfWork = unitOfWork;
        _repairOrderRepository = repairOrderRepository;
    }
    public async Task<Guid> Handle(CreateRepairOrderCommand request, CancellationToken cancellationToken)
    {
        var repairCost = new Money(request.RepairOrder.RepairCost, request.RepairOrder.RepairCostCurrency);
        var repairOrder = new RepairOrderEntity(request.RepairOrder.VehicleId,repairCost, request.RepairOrder.Description);

        await _repairOrderRepository.AddAsync(repairOrder,cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return repairOrder.Id;
    }
}