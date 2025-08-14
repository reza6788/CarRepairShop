using CarRepairShop.Application.Interfaces;
using CarRepairShop.Domain.Aggregates.MechanicAggregate;
using CarRepairShop.Domain.Interfaces;
using CarRepairShop.Domain.ValueObjects;
using MediatR;

namespace CarRepairShop.Application.Commands.Mechanic;

public class UpdateMechanicCommandHandler : IRequestHandler<UpdateMechanicCommand>
{
    private readonly IGenericRepository<MechanicEntity> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateMechanicCommandHandler(IGenericRepository<MechanicEntity> repository,IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(UpdateMechanicCommand request, CancellationToken cancellationToken)
    {
        var mechanic = await _repository.GetByIdAsync(request.Mechanic.Id, cancellationToken);
        if (mechanic == null) throw new Exception("Mechanic not found");

        var fullName = new FullName(request.Mechanic.FirstName, request.Mechanic.LastName);
        mechanic.UpdateName(fullName);
        mechanic.UpdateSpecialty(request.Mechanic.Specialty);

        mechanic.MarkAsUpdated();
        _repository.Update(mechanic);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}