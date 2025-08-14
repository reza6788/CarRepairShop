using CarRepairShop.Application.DTOs.RepairOrder;
using MediatR;

namespace CarRepairShop.Application.Queries.RepairOrder;

public record GetOpenRepairOrdersQuery : IRequest<IEnumerable<RepairOrderDto>>;