using CarRepairShop.Application.Interfaces;
using CarRepairShop.Domain.Aggregates.MechanicAggregate;
using CarRepairShop.Domain.Interfaces;
using MediatR;

namespace CarRepairShop.Application.Commands.Mechanic;

public class DeleteMechanicCommandHandler : IRequestHandler<DeleteMechanicCommand>
{
    private readonly IGenericRepository<MechanicEntity> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMechanicCommandHandler(IGenericRepository<MechanicEntity> repository,IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Handle(DeleteMechanicCommand request, CancellationToken cancellationToken)
    {
        var mechanic = await _repository.GetByIdAsync(request.Mechanic.Id, cancellationToken);
        if (mechanic == null) throw new Exception("Mechanic not found");

        mechanic.MarkAsDeleted();

        _repository.Update(mechanic);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}