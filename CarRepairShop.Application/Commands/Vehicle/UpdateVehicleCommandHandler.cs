using CarRepairShop.Application.Interfaces;
using CarRepairShop.Domain.Aggregates.CustomerAggregate;
using CarRepairShop.Domain.Interfaces;
using CarRepairShop.Domain.ValueObjects;
using MediatR;

namespace CarRepairShop.Application.Commands.Vehicle;

public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand>
{
    private readonly IGenericRepository<VehicleEntity> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVehicleCommandHandler(IGenericRepository<VehicleEntity> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await _repository.GetByIdAsync(request.Vehicle.Id, cancellationToken);
        if (vehicle == null) throw new Exception("Vehicle not found");

        vehicle.LicensePlate = new LicensePlate(request.Vehicle.LicensePlateNumber);
        vehicle.Make = request.Vehicle.Make;
        vehicle.Model = request.Vehicle.Model;
        vehicle.Year = request.Vehicle.Year;
        vehicle.CustomerId = request.Vehicle.CustomerId;
        
        vehicle.MarkAsUpdated();
        _repository.Update(vehicle);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}