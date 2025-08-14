using CarRepairShop.Application.Behaviors;
using CarRepairShop.Application.Commands.Customer;
using CarRepairShop.Application.Interfaces;
using CarRepairShop.Application.Mapping;
using CarRepairShop.Application.Services.Email;
using CarRepairShop.Application.Services.Models;
using CarRepairShop.Domain.Interfaces;
using CarRepairShop.Infrastructure;
using CarRepairShop.Infrastructure.Persistence;
using CarRepairShop.Infrastructure.Persistence.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.OpenApi.Models;

namespace CarRepairShop.API.Registers;

public static class ServiceRegistry
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
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

        var smtpSettings = new SmtpSettings
        {
            FromEmail = builder.Configuration["SMTP_FromEmail"] ?? "",
            FromName = builder.Configuration["SMTP_FromName"] ?? "",
            Host = builder.Configuration["SMTP_HOST"] ?? "",
            Port = int.TryParse(builder.Configuration["SMTP_PORT"], out var port) ? port : 25,
            Username = builder.Configuration["SMTP_USERNAME"] ?? "",
            Password = builder.Configuration["SMTP_PASSWORD"] ?? "",
            EnableSsl = bool.TryParse(builder.Configuration["SMTP_ENABLE_SSL"], out var ssl) && ssl
        };

        builder.Services.AddSingleton(smtpSettings);


        // DI setup
        builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<IMechanicRepository, MechanicRepository>();
        builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
        builder.Services.AddScoped<IRepairOrderRepository, RepairOrderRepository>();
        builder.Services.AddTransient<IEmailService, EmailService>();

        //Register Unit of Work
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Validator Behavior
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        builder.Services.AddValidatorsFromAssembly(typeof(ValidationBehavior<,>).Assembly);
    }
}