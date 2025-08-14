using AutoMapper;
using CarRepairShop.Application.DTOs.RepairOrder;
using CarRepairShop.Domain.Interfaces;
using MediatR;

namespace CarRepairShop.Application.Queries.RepairOrder;

public class GetOpenRepairOrdersQueryHandler : IRequestHandler<GetOpenRepairOrdersQuery,IEnumerable<RepairOrderDto>>
{
    private readonly IRepairOrderRepository _repository;
    private readonly IMapper _mapper;

    public GetOpenRepairOrdersQueryHandler(IRepairOrderRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<RepairOrderDto>> Handle(GetOpenRepairOrdersQuery request, CancellationToken cancellationToken)
    {
       var repairOrders=await _repository.GetOpenRepairOrdersAsync(cancellationToken);
       return _mapper.Map<IEnumerable<RepairOrderDto>>(repairOrders); 
    }
}