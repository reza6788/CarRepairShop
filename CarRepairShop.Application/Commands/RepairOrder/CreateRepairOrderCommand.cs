using CarRepairShop.Application.DTOs.RepairOrder;
using MediatR;

namespace CarRepairShop.Application.Commands.RepairOrder;

public record CreateRepairOrderCommand(CreateRepairOrderDto RepairOrder) : IRequest<Guid>;