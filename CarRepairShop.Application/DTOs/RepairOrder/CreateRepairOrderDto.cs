using CarRepairShop.Domain.ValueObjects;

namespace CarRepairShop.Application.DTOs.RepairOrder;

public class CreateRepairOrderDto
{
    public Guid VehicleId { get; set; }
    public decimal RepairCost { get; set; }
    public string RepairCostCurrency { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}