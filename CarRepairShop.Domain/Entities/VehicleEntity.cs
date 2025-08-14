using CarRepairShop.Domain.ValueObjects;

namespace CarRepairShop.Domain.Entities;

public class VehicleEntity : BaseEntity
{
    public LicensePlate LicensePlate { get; set; } = null!;
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public CustomerEntity Customer { get; set; }
    public Guid CustomerId { get; set; }
    
    private VehicleEntity() { }

    public VehicleEntity(LicensePlate licensePlate, string make, string model, int year, Guid customerId)
    {
        LicensePlate = licensePlate ?? throw new ArgumentNullException(nameof(licensePlate));
        Make = make ?? throw new ArgumentNullException(nameof(make));
        Model = model ?? throw new ArgumentNullException(nameof(model));
        Year = year;
        CustomerId = customerId;
    }
}