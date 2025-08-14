using CarRepairShop.Domain.Interfaces;

namespace CarRepairShop.Domain.Events.Customer;

public class CreateCustomerEvent : IDomainEvent
{
    public Guid CustomerId { get; }
    public string FullName { get; }
    public DateTime OccurredOn { get; } = DateTime.UtcNow;

    public CreateCustomerEvent(Guid customerId, string fullName)
    {
        CustomerId = customerId;
        FullName = fullName;
    }
}