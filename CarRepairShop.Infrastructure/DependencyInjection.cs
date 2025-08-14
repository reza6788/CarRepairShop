using CarRepairShop.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace CarRepairShop.Infrastructure;

public static class DependencyInjection
{
    public static void AddDatabase(this IServiceCollection services)
    {
        var connectionString = ConnectionStringBuilder.GetConnectionStringFromConfiguration();
        
        // Register EF DbContext
        services.AddScoped<CrsDbContext>(_ => new CrsDbContext(connectionString));
    }
}