using Projects;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<CarRepairShop_API>("API");
builder.AddProject<CarRepairShop_App>("BlazorApp");

builder.Build().Run();