using CarRepairShop.Domain.Aggregates.MechanicAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRepairShop.Infrastructure.Configurations;

public class MechanicConfiguration : IEntityTypeConfiguration<MechanicEntity>
{
    public void Configure(EntityTypeBuilder<MechanicEntity> builder)
    {
        builder.HasKey(m => m.Id);

        // Mapping FullName as an owned type
        builder.OwnsOne(m => m.Name, name =>
        {
            name.Property(n => n.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            name.Property(n => n.LastName)
                .HasMaxLength(100)
                .IsRequired();
        });

        builder.Property(m => m.Specialty)
            .HasMaxLength(100)
            .IsRequired();
    }
}