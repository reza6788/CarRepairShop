using CarRepairShop.Domain.Entities;

namespace CarRepairShop.Domain.Interfaces;

public interface IMechanicRepository : IGenericRepository<MechanicEntity>
{
    Task<IEnumerable<MechanicEntity>> GetBySpecialtyAsync(string specialty);
}