using CarRepairShop.Domain.Events.RepairOrder;
using MediatR;

namespace CarRepairShop.Application.EventHandlers.RepairOrder;

public class RepairOrderCreatedEventHandler : INotificationHandler<RepairOrderCreatedEvent>
{
    public Task Handle(RepairOrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Order created: {notification.OccurredOn} " +
                          $"(Id: {notification.RepairOrderId}) " +
                          $"(vehicle id): {notification.VehicleId}");
        return Task.CompletedTask;
    }
}