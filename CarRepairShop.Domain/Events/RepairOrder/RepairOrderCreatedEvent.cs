using CarRepairShop.Domain.Interfaces;

namespace CarRepairShop.Domain.Events.RepairOrder;

public class RepairOrderCreatedEvent : IDomainEvent
{
    public Guid RepairOrderId { get; }
    public Guid VehicleId { get; }
    public Guid? MechanicId { get; }

    public DateTime OccurredOn { get; } = DateTime.UtcNow;

    public RepairOrderCreatedEvent(Guid repairOrderId, Guid vehicleId, Guid mechanicId)
    {
        VehicleId = vehicleId;
        RepairOrderId = repairOrderId;
        MechanicId = mechanicId;
    }
}