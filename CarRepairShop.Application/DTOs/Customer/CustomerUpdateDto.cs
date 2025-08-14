namespace CarRepairShop.Application.DTOs.Customer;

public class CustomerUpdateDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty; 
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}