using CarRepairShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRepairShop.Infrastructure.Configurations;

public class RepairOrderEntityConfiguration : IEntityTypeConfiguration<RepairOrderEntity>
{
    public void Configure(EntityTypeBuilder<RepairOrderEntity> builder)
    {
        builder.HasKey(ro => ro.Id);

        builder.Property(ro => ro.Description)
            .HasMaxLength(500)
            .IsRequired();

        builder.OwnsOne(ro => ro.RepairCost, rp =>
        {
            rp.Property(r => r.Amount)
                .HasPrecision(10, 2)
                .IsRequired();
            rp.Property(r => r.Currency)
                .HasMaxLength(3);
        });

        builder.Property(ro => ro.IsCompleted)
            .IsRequired();

        builder.HasOne(ro => ro.Vehicle)
            .WithMany()
            .HasForeignKey(ro => ro.VehicleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ro => ro.Mechanic)
            .WithMany()
            .HasForeignKey(ro => ro.MechanicId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}