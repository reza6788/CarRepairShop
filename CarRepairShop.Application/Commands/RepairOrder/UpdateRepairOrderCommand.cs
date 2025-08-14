using CarRepairShop.Application.DTOs.RepairOrder;
using MediatR;

namespace CarRepairShop.Application.Commands.RepairOrder;

public record UpdateRepairOrderCommand(UpdateRepairOrderDto RepairOrder) : IRequest;