using CarRepairShop.Domain.ValueObjects;

namespace CarRepairShop.Domain.Aggregates.CustomerAggregate;

public class CustomerEntity : BaseEntity
{
    public FullName Name { get; private set; } = null!;
    public string PhoneNumber { get; private set; } = string.Empty;

    public List<VehicleEntity> Vehicles { get; set; }
    private CustomerEntity() { }
    
    public CustomerEntity(FullName name, string phoneNumber)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
    }
    
    public void UpdateName(FullName newName)
    {
        Name = newName ?? throw new ArgumentNullException(nameof(newName));
    }
    
    public void UpdatePhoneNumber(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new ArgumentException("Phone number cannot be empty", nameof(phoneNumber));
        PhoneNumber = phoneNumber;
    }

   
}