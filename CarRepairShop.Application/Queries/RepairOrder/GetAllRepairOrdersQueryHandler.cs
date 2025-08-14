using AutoMapper;
using CarRepairShop.Application.DTOs.RepairOrder;
using CarRepairShop.Domain.Interfaces;
using MediatR;

namespace CarRepairShop.Application.Queries.RepairOrder;

public class GetAllRepairOrdersQueryHandler : IRequestHandler<GetAllRepairOrdersQuery, IEnumerable<RepairOrderDto>>
{
    private readonly IRepairOrderRepository _repository;
    private readonly IMapper _mapper;

    public GetAllRepairOrdersQueryHandler(IRepairOrderRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RepairOrderDto>> Handle(GetAllRepairOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _repository.GetAllRepairOrdersAsync(cancellationToken);
        return _mapper.Map<IEnumerable<RepairOrderDto>>(orders);
    }
}