using CarRepairShop.Application.DTOs.Mechanic;
using MediatR;

namespace CarRepairShop.Application.Commands.Mechanic;

public record DeleteMechanicCommand(MechanicDeleteDto Mechanic) : IRequest;