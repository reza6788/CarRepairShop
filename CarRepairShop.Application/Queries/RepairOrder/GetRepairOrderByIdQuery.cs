using CarRepairShop.Application.DTOs.RepairOrder;
using MediatR;

namespace CarRepairShop.Application.Queries.RepairOrder;

public record GetRepairOrderByIdQuery(Guid Id) : IRequest<RepairOrderDto>;