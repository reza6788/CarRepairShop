using CarRepairShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRepairShop.Infrastructure.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<CustomerEntity>
{
    public void Configure(EntityTypeBuilder<CustomerEntity> builder)
    {
        builder.HasKey(c => c.Id);

        builder.OwnsOne(c => c.Name, name =>
        {
            name.Property(n => n.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            name.Property(n => n.LastName)
                .HasMaxLength(100)
                .IsRequired();
        });

        builder.Property(c => c.PhoneNumber)
            .HasMaxLength(15)
            .IsRequired();

        builder.HasMany(c => c.Vehicles)
            .WithOne(p=>p.Customer)
            .HasForeignKey(p=>p.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}