using CarRepairShop.Application.DTOs.Mechanic;
using MediatR;

namespace CarRepairShop.Application.Commands.Mechanic;

public record CreateMechanicCommand(MechanicCreateDto Mechanic) : IRequest<Guid>;