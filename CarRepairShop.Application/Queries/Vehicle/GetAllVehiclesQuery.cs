using CarRepairShop.Application.DTOs.Vehicle;
using MediatR;

namespace CarRepairShop.Application.Queries.Vehicle;

public record GetAllVehiclesQuery() : IRequest<IEnumerable<VehicleDto>>;