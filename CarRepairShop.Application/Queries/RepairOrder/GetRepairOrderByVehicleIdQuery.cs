using CarRepairShop.Application.DTOs.RepairOrder;
using MediatR;

namespace CarRepairShop.Application.Queries.RepairOrder;

public record GetRepairOrderByVehicleIdQuery(Guid VehicleId) : IRequest<List<RepairOrderDto>>;