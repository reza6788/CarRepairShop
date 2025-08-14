using CarRepairShop.Domain.Entities;
using CarRepairShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarRepairShop.Infrastructure;

public class CrsDbContext : DbContext
{
    private string _connectionString = string.Empty;
    public CrsDbContext() {}
    public CrsDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    public CrsDbContext(DbContextOptions<CrsDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(string.IsNullOrEmpty(_connectionString))
            _connectionString = ConnectionStringBuilder.GetConnectionStringFromConfiguration();

        optionsBuilder.UseSqlServer(_connectionString,
            builder => { builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null); });
        base.OnConfiguring(optionsBuilder);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CrsDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<CustomerEntity> Customers { get; set; } = null!;
    public DbSet<VehicleEntity> Vehicles { get; set; } = null!;
    public DbSet<MechanicEntity> Mechanics { get; set; } = null!;
    public DbSet<RepairOrderEntity?> RepairOrders { get; set; } = null!;
    
  
}