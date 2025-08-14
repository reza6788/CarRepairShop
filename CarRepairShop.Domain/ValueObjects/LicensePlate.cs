namespace CarRepairShop.Domain.ValueObjects;

public class LicensePlate
{
    public string Value { get; private set; } = string.Empty;

    private LicensePlate(){ }
    public LicensePlate(string value)
    {
        if(string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
        Value = value;
    }
}