namespace CarRepairShop.Application.DTOs.RepairOrder;

public class UpdateRepairOrderDto
{
    public Guid Id { get; set; }
    public Guid? MechanicId { get; set; }
    public decimal RepairCost { get; set; }
    public string RepairCostCurrency { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool? IsCompleted { get; set; }
}