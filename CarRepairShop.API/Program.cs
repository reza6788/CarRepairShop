using CarRepairShop.API.Registers;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureServices();

var app = builder.Build();

app.ConfigureMiddlewares();
await app.RunAsync();