using CarRepairShop.Domain.Entities;

namespace CarRepairShop.Domain.Interfaces;

public interface IRepairOrderRepository : IGenericRepository<RepairOrderEntity>
{
    Task<List<RepairOrderEntity>> GetAllRepairOrdersAsync(CancellationToken cancellationToken = default);
    Task<RepairOrderEntity?> GetByIdRepairOrderAsync(Guid repairOrderId, CancellationToken cancellationToken = default);

    Task<IEnumerable<RepairOrderEntity>> GetRepairOrdersByVehicleIdAsync(Guid vehicleId,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<RepairOrderEntity>> GetOpenRepairOrdersAsync(CancellationToken cancellationToken = default);
}