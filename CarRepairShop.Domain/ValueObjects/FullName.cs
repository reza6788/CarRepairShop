namespace CarRepairShop.Domain.ValueObjects;

public class FullName
{
    public string FirstName { get; private set; } =string.Empty;
    public string LastName { get; private set; } =string.Empty;
    
    private FullName(){}

    public FullName(string firstName, string lastName)
    {
        if(string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException($"'{nameof(firstName)}' cannot be null or whitespace.", nameof(firstName));
        if(string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException($"'{nameof(lastName)}' cannot be null or whitespace.", nameof(lastName));
        
        FirstName = firstName;
        LastName = lastName;
    }
}