using CarRepairShop.Domain.Aggregates.CustomerAggregate;
using CarRepairShop.Domain.Aggregates.MechanicAggregate;
using CarRepairShop.Domain.ValueObjects;

namespace CarRepairShop.Domain.Aggregates.RepairOrderAggregate;

public class RepairOrderEntity : BaseEntity
{
    public Guid VehicleId { get; private set; }
    public VehicleEntity Vehicle { get; private set; } = null!;
    public Guid? MechanicId { get; private set; }
    public MechanicEntity? Mechanic { get; private set; } = null!;
    public Money RepairCost { get; private set; }
    public string Description { get; private set; }
    public bool IsCompleted { get; private set; }

    private RepairOrderEntity()
    {
    }

    public RepairOrderEntity(Guid vehicleId, Money repairCost, string description)
    {
        VehicleId = vehicleId;
        RepairCost = repairCost;
        Description = description ?? throw new ArgumentNullException(nameof(description));
        IsCompleted = false;
    }

    public void UpdateRepairCost(Money repairCost)
    {
        RepairCost = repairCost;
    }

    public void AssignMechanic(Guid mechanicId)
    {
        MechanicId = mechanicId;
    }

    public void UpdateDescription(string newDescription)
    {
        Description = newDescription ?? throw new ArgumentNullException(nameof(newDescription));
    }

    public void MarkCompleted()
    {
        IsCompleted = true;
    }
}