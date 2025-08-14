using CarRepairShop.Application.DTOs.Vehicle;
using MediatR;

namespace CarRepairShop.Application.Queries.Vehicle;

public record GetVehicleByIdQuery(Guid Id) : IRequest<VehicleDto>;