using MediatR;

namespace CarRepairShop.Application.Commands.RepairOrder;

public record CompleteRepairOrderCommand(Guid RepairOrderId) : IRequest;