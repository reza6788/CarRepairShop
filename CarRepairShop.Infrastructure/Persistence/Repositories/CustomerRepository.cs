using CarRepairShop.Domain.Aggregates.CustomerAggregate;
using CarRepairShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRepairShop.Infrastructure.Persistence.Repositories;

public class CustomerRepository : GenericRepository<CustomerEntity>,ICustomerRepository
{
    private readonly CrsDbContext _dbContext;

    public CustomerRepository(CrsDbContext dbContext) :base(context: dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CustomerEntity?> GetByPhoneNumberAsync(string phoneNumber)
    {
        return await _dbContext.Customers
            .FirstOrDefaultAsync(c => c.PhoneNumber == phoneNumber);
    }
    
    public async Task<List<CustomerEntity>> GetAllWithVehiclesAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Customers
            .Include(c => c.Vehicles) 
            .ToListAsync(cancellationToken);
    }
}