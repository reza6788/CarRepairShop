namespace CarRepairShop.Domain;

public abstract class BaseEntity
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public DateTime CreateDateTime { get; private set; } = DateTime.UtcNow;

    public DateTime? LastChangeDateTime { get; private set; }

    public bool IsDeleted { get; private set; }

    public DateTime? DeleteDateTime { get; private set; }

    public void MarkAsUpdated()
    {
        LastChangeDateTime = DateTime.UtcNow;
    }

    public void MarkAsDeleted()
    {
        if (!IsDeleted)
        {
            IsDeleted = true;
            DeleteDateTime = DateTime.UtcNow;
        }
    }

    public void Restore()
    {
        if (IsDeleted)
        {
            IsDeleted = false;
            DeleteDateTime = null;
        }
    }
}