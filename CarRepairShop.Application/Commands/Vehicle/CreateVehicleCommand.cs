using CarRepairShop.Application.DTOs.Vehicle;
using MediatR;

namespace CarRepairShop.Application.Commands.Vehicle;

public record CreateVehicleCommand(VehicleCreateDto Vehicle) : IRequest<Guid>;