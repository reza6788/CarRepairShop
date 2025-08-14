using CarRepairShop.Domain.Entities;
using CarRepairShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRepairShop.Infrastructure.Persistence.Repositories;

public class VehicleRepository : GenericRepository<VehicleEntity>, IVehicleRepository
{
    public CrsDbContext Context { get; }

    public VehicleRepository(CrsDbContext context) : base(context)
    {
        Context = context;
    }

    public async Task<VehicleEntity?> GetByLicensePlateAsync(string licensePlate)
    {
        return await _context.Vehicles
            .FirstOrDefaultAsync(v => v.LicensePlate.Value == licensePlate.ToUpper());
    }
}