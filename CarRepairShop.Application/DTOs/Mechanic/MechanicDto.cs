namespace CarRepairShop.Application.DTOs.Mechanic;

public class MechanicDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Specialty { get; set; } = string.Empty;
}