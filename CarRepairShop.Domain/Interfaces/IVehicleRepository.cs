using CarRepairShop.Domain.Entities;

namespace CarRepairShop.Domain.Interfaces;

public interface IVehicleRepository: IGenericRepository<VehicleEntity>
{
    Task<VehicleEntity?> GetByLicensePlateAsync(string licensePlate);
}