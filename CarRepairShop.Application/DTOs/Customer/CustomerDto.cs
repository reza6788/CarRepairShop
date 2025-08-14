using CarRepairShop.Application.DTOs.Vehicle;

namespace CarRepairShop.Application.DTOs.Customer;

public class CustomerDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public string PhoneNumber { get; set; } = string.Empty;
    public List<VehicleSummaryDto> Vehicles { get; set; } = null!;
}