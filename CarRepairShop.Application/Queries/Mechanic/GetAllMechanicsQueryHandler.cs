using AutoMapper;
using CarRepairShop.Application.DTOs.Mechanic;
using CarRepairShop.Domain.Aggregates.MechanicAggregate;
using CarRepairShop.Domain.Interfaces;
using MediatR;

namespace CarRepairShop.Application.Queries.Mechanic;

public class GetAllMechanicsQueryHandler : IRequestHandler<GetAllMechanicsQuery, IEnumerable<MechanicDto>>
{
    private readonly IGenericRepository<MechanicEntity> _repository;
    private readonly IMapper _mapper;

    public GetAllMechanicsQueryHandler(IGenericRepository<MechanicEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MechanicDto>> Handle(GetAllMechanicsQuery request,
        CancellationToken cancellationToken)
    {
        var mechanics = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<MechanicDto>>(mechanics);
    }
}