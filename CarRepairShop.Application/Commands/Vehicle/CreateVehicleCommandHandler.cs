using CarRepairShop.Application.Interfaces;
using CarRepairShop.Domain.Aggregates.CustomerAggregate;
using CarRepairShop.Domain.Interfaces;
using CarRepairShop.Domain.ValueObjects;
using MediatR;

namespace CarRepairShop.Application.Commands.Vehicle;

public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, Guid>
{
    private readonly IGenericRepository<VehicleEntity> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateVehicleCommandHandler(IGenericRepository<VehicleEntity> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var licensePlate = new LicensePlate(request.Vehicle.LicensePlateNumber);
        var vehicle = new VehicleEntity(licensePlate, request.Vehicle.Make, request.Vehicle.Model, request.Vehicle.Year,
            request.Vehicle.CustomerId);
        await _repository.AddAsync(vehicle, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return vehicle.Id;
    }
}