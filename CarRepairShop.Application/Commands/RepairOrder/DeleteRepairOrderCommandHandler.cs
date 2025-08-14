using CarRepairShop.Application.Interfaces;
using CarRepairShop.Domain.Entities;
using CarRepairShop.Domain.Interfaces;
using MediatR;

namespace CarRepairShop.Application.Commands.RepairOrder;

public class DeleteRepairOrderCommandHandler : IRequestHandler<DeleteRepairOrderCommand>
{
    private readonly IGenericRepository<RepairOrderEntity> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRepairOrderCommandHandler(IGenericRepository<RepairOrderEntity> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(DeleteRepairOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetByIdAsync(request.RepairOrder.Id, cancellationToken);
        if (order == null) throw new Exception("Repair order not found");

        order.MarkAsDeleted();

        _repository.Update(order);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}