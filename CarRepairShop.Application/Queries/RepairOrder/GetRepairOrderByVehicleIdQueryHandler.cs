using AutoMapper;
using CarRepairShop.Application.DTOs.RepairOrder;
using CarRepairShop.Domain.Entities;
using CarRepairShop.Domain.Interfaces;
using MediatR;

namespace CarRepairShop.Application.Queries.RepairOrder;

public class
    GetRepairOrderByVehicleIdQueryHandler : IRequestHandler<GetRepairOrderByVehicleIdQuery, List<RepairOrderDto>>
{
    private readonly IRepairOrderRepository _repository;
    private readonly IMapper _mapper;

    public GetRepairOrderByVehicleIdQueryHandler(IRepairOrderRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<RepairOrderDto>> Handle(GetRepairOrderByVehicleIdQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _repository.GetRepairOrdersByVehicleIdAsync(request.VehicleId, cancellationToken);
        return _mapper.Map<List<RepairOrderDto>>(result);
    }
}