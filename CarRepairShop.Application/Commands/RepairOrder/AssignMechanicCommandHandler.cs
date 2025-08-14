using CarRepairShop.Application.Interfaces;
using CarRepairShop.Domain.Aggregates.MechanicAggregate;
using CarRepairShop.Domain.Aggregates.RepairOrderAggregate;
using CarRepairShop.Domain.Interfaces;
using MediatR;

namespace CarRepairShop.Application.Commands.RepairOrder;

public class AssignMechanicCommandHandler : IRequestHandler<AssignMechanicCommand>
{
    private readonly IGenericRepository<RepairOrderEntity> _repository;
    private readonly IGenericRepository<MechanicEntity> _mechanicRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AssignMechanicCommandHandler(IGenericRepository<RepairOrderEntity> repository,
        IGenericRepository<MechanicEntity> mechanicRepository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _mechanicRepository = mechanicRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(AssignMechanicCommand request, CancellationToken cancellationToken)
    {
        var mechanic = await _mechanicRepository.GetByIdAsync(request.MechanicId, cancellationToken);
        if (mechanic == null) throw new Exception("Mechanic not found");
        var order = await _repository.GetByIdAsync(request.RepairOrderId, cancellationToken);
        if (order == null) throw new Exception("Repair order not found");

        order.AssignMechanic(request.MechanicId);

        _repository.Update(order);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}