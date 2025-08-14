namespace CarRepairShop.Application.DTOs.Vehicle;

public class VehicleCreateDto
{
    public string LicensePlateNumber { get; set; } = string.Empty; // چون LicensePlate یک VO است
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public Guid CustomerId { get; set; }
}