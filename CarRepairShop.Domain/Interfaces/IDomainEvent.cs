using MediatR;

namespace CarRepairShop.Domain.Interfaces;

public interface IDomainEvent : INotification
{
    DateTime OccurredOn { get; }
}