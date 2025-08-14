using CarRepairShop.Application.Interfaces;
using CarRepairShop.Domain.Aggregates.CustomerAggregate;
using CarRepairShop.Domain.Interfaces;
using MediatR;

namespace CarRepairShop.Application.Commands.Vehicle;

public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand>
{
    private readonly IGenericRepository<VehicleEntity> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVehicleCommandHandler(IGenericRepository<VehicleEntity> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await _repository.GetByIdAsync(request.Vehicle.Id, cancellationToken);
        if (vehicle == null) throw new Exception("Vehicle not found");

        vehicle.MarkAsDeleted();

        _repository.Update(vehicle);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}