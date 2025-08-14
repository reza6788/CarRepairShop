using CarRepairShop.Application.Interfaces;
using CarRepairShop.Domain.Aggregates.MechanicAggregate;
using CarRepairShop.Domain.Interfaces;
using CarRepairShop.Domain.ValueObjects;
using MediatR;

namespace CarRepairShop.Application.Commands.Mechanic;

public class CreateMechanicCommandHandler : IRequestHandler<CreateMechanicCommand, Guid>
{
    private readonly IGenericRepository<MechanicEntity> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateMechanicCommandHandler(IGenericRepository<MechanicEntity> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Guid> Handle(CreateMechanicCommand request, CancellationToken cancellationToken)
    {
        var fullName = new FullName(request.Mechanic.FirstName, request.Mechanic.LastName);
        var mechanic = new MechanicEntity(fullName, request.Mechanic.Specialty);
        await _repository.AddAsync(mechanic, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return mechanic.Id;
    }
}