using CarRepairShop.Domain.Entities;
using CarRepairShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRepairShop.Infrastructure.Persistence.Repositories;

public class MechanicRepository : GenericRepository<MechanicEntity>,IMechanicRepository
{
    public CrsDbContext Context { get; }

    public MechanicRepository(CrsDbContext context) : base(context)
    {
        Context = context;
    }

    public async Task<IEnumerable<MechanicEntity>> GetBySpecialtyAsync(string specialty)
    {
        return await _context.Mechanics
            .Where(m => m.Specialty.ToLower() == specialty.ToLower())
            .ToListAsync();
    }
}