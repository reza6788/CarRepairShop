using CarRepairShop.Application.DTOs.Mechanic;
using CarRepairShop.Application.DTOs.Vehicle;

namespace CarRepairShop.Application.DTOs.RepairOrder;

public class RepairOrderDto
{
    public Guid Id { get; set; }
    public VehicleDto Vehicle { get; set; } = null!;
    public MechanicDto? Mechanic { get; set; }
    public decimal RepairCost { get; set; }
    public string RepairCostCurrency { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}