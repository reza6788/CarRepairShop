using CarRepairShop.Application.DTOs.Mechanic;
using MediatR;

namespace CarRepairShop.Application.Queries.Mechanic;

public record GetAllMechanicsQuery() : IRequest<IEnumerable<MechanicDto>>;