namespace CarRepairShop.Application.DTOs.Vehicle;

public class VehicleSummaryDto
{
    public Guid Id { get; set; }
    public string LicensePlateNumber { get; set; } = string.Empty;
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
}