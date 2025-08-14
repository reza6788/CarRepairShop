using CarRepairShop.Domain.Aggregates.CustomerAggregate;

namespace CarRepairShop.Domain.Interfaces;

public interface IVehicleRepository: IGenericRepository<VehicleEntity>
{
    Task<VehicleEntity?> GetByLicensePlateAsync(string licensePlate);
}