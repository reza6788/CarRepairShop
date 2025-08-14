using CarRepairShop.Domain.Entities;
using CarRepairShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRepairShop.Infrastructure.Persistence.Repositories;

public class RepairOrderRepository : GenericRepository<RepairOrderEntity>, IRepairOrderRepository
{
    public CrsDbContext Context { get; }

    public RepairOrderRepository(CrsDbContext context) : base(context)
    {
        Context = context;
    }

    public async Task<IEnumerable<RepairOrderEntity>> GetOpenRepairOrdersAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.RepairOrders
            .Include(ro => ro.Mechanic)
            .Include(ro => ro.Vehicle)
            .Where(ro => !ro.IsCompleted && !ro.IsDeleted)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<RepairOrderEntity>> GetAllRepairOrdersAsync(CancellationToken cancellationToken = default)
    {
        return (await _context.RepairOrders
            .Include(ro => ro.Mechanic)
            .Include(ro => ro.Vehicle)
            .Where(ro => !ro.IsDeleted)
            .ToListAsync(cancellationToken));
    }

    public async Task<RepairOrderEntity?> GetByIdRepairOrderAsync(Guid repairOrderId,
        CancellationToken cancellationToken = default)
    {
        return await _context.RepairOrders
            .Include(ro => ro.Mechanic)
            .Include(ro => ro.Vehicle)
            .FirstOrDefaultAsync(ro => !ro.IsDeleted && ro.Id == repairOrderId, cancellationToken);
    }

    public async Task<IEnumerable<RepairOrderEntity>> GetRepairOrdersByVehicleIdAsync(Guid vehicleId,
        CancellationToken cancellationToken = default)
    {
        return await _context.RepairOrders
            .Include(ro => ro.Mechanic)
            .Include(ro => ro.Vehicle)
            .Where(ro => !ro.IsDeleted & ro.VehicleId == vehicleId)
            .ToListAsync(cancellationToken);
    }
}