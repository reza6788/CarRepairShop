using CarRepairShop.API.Filters;
using CarRepairShop.Application.Behaviors;
using CarRepairShop.Application.Commands.Customer;
using CarRepairShop.Application.Interfaces;
using CarRepairShop.Application.Mapping;
using CarRepairShop.Domain.Interfaces;
using CarRepairShop.Infrastructure;
using CarRepairShop.Infrastructure.Persistence;
using CarRepairShop.Infrastructure.Persistence.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SupportNonNullableReferenceTypes();
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SchoolProvider API",
        Version = "v1",
        Description = "API for managing students, classrooms, and school data",
        Contact = new OpenApiContact
        {
            Name = "Team Name",
            Email = "a@b.com"
        }
    });
});

// Configure application databases
builder.Services.AddDatabase();

// MediatR
builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssembly(typeof(CreateCustomerCommandHandler).Assembly));

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// DI setup
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IMechanicRepository, MechanicRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IRepairOrderRepository, RepairOrderRepository>();

//Register Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Validator Behavior
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddValidatorsFromAssembly(typeof(ValidationBehavior<,>).Assembly);

var app = builder.Build();

app.UseHttpsRedirection();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "SchoolProvider API V1");
        options.RoutePrefix = "swagger"; // swagger UI at /swagger
    });
}

app.MapControllers();

app.MapGet("/",
    context =>
    {
        context.Response.Redirect("/swagger");
        return Task.CompletedTask;
    }).AllowAnonymous();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.Run();

