using MediatR;

namespace CarRepairShop.Application.Commands.RepairOrder;

public record AssignMechanicCommand(Guid RepairOrderId, Guid MechanicId) : IRequest;