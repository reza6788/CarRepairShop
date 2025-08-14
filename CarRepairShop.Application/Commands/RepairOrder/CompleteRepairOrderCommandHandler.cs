using CarRepairShop.Application.Interfaces;
using CarRepairShop.Domain.Aggregates.RepairOrderAggregate;
using CarRepairShop.Domain.Interfaces;
using MediatR;

namespace CarRepairShop.Application.Commands.RepairOrder;

public class CompleteRepairOrderCommandHandler: IRequestHandler<CompleteRepairOrderCommand>
{
    private readonly IGenericRepository<RepairOrderEntity> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CompleteRepairOrderCommandHandler(IGenericRepository<RepairOrderEntity> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CompleteRepairOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetByIdAsync(request.RepairOrderId, cancellationToken);
        if (order == null) throw new Exception("Repair order not found");

        order.MarkCompleted();

        _repository.Update(order);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}