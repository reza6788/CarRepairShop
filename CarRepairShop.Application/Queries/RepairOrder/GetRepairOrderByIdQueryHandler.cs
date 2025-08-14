using AutoMapper;
using CarRepairShop.Application.DTOs.RepairOrder;
using CarRepairShop.Domain.Entities;
using CarRepairShop.Domain.Interfaces;
using MediatR;

namespace CarRepairShop.Application.Queries.RepairOrder;

public class GetRepairOrderByIdQueryHandler : IRequestHandler<GetRepairOrderByIdQuery, RepairOrderDto>
{
    private readonly IRepairOrderRepository _repository;
    private readonly IMapper _mapper;

    public GetRepairOrderByIdQueryHandler(IRepairOrderRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<RepairOrderDto> Handle(GetRepairOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetByIdAsync(request.Id,cancellationToken);
        return _mapper.Map<RepairOrderDto>(order);
    }
}