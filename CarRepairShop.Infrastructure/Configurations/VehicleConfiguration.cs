using CarRepairShop.Domain.Aggregates.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRepairShop.Infrastructure.Configurations;

public class VehicleEntityConfiguration : IEntityTypeConfiguration<VehicleEntity>
{
    public void Configure(EntityTypeBuilder<VehicleEntity> builder)
    {

        builder.HasKey(v => v.Id);

        // Value Object - LicensePlate
        builder.OwnsOne(v => v.LicensePlate, lp =>
        {
            lp.Property(l => l.Value)
                .HasMaxLength(20)
                .IsRequired();
        });

        builder.Property(v => v.Make)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(v => v.Model)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(v => v.Year)
            .IsRequired();

        builder.HasOne(p=>p.Customer)
            .WithMany(p=>p.Vehicles)
            .HasForeignKey(v => v.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}