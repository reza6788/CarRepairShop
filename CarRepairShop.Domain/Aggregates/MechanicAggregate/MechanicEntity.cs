using CarRepairShop.Domain.ValueObjects;

namespace CarRepairShop.Domain.Aggregates.MechanicAggregate;

public class MechanicEntity : BaseEntity
{
    public FullName Name { get; private set; } = null!;
    public string Specialty { get; private set; } = string.Empty;

    private MechanicEntity()
    {
    }

    public MechanicEntity(FullName name, string specialty)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Specialty = specialty ?? throw new ArgumentNullException(nameof(specialty));
    }
    
    public void UpdateName(FullName newName)
    {
        Name = newName ?? throw new ArgumentNullException(nameof(newName));
    }
    
    public void UpdateSpecialty(string newSpecialty)
    {
        Specialty = newSpecialty ?? throw new ArgumentNullException(nameof(newSpecialty));
    }
}