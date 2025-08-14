using CarRepairShop.Domain.Aggregates.CustomerAggregate;

namespace CarRepairShop.Domain.Interfaces;

public interface ICustomerRepository: IGenericRepository<CustomerEntity>
{
    Task<CustomerEntity?> GetByPhoneNumberAsync(string phoneNumber);
    Task<List<CustomerEntity>> GetAllWithVehiclesAsync(CancellationToken cancellationToken);
}