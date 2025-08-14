using CarRepairShop.Application.DTOs.Vehicle;
using MediatR;

namespace CarRepairShop.Application.Commands.Vehicle;

public record UpdateVehicleCommand(VehicleUpdateDto Vehicle) : IRequest;