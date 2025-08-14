using AutoMapper;
using CarRepairShop.Application.DTOs.Mechanic;
using CarRepairShop.Domain.Entities;
using CarRepairShop.Domain.Interfaces;
using MediatR;

namespace CarRepairShop.Application.Queries.Mechanic;

public class GetMechanicByIdQueryHandler : IRequestHandler<GetMechanicByIdQuery, MechanicDto>
{
    private readonly IGenericRepository<MechanicEntity> _repository;
    private readonly IMapper _mapper;

    public GetMechanicByIdQueryHandler(IGenericRepository<MechanicEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<MechanicDto> Handle(GetMechanicByIdQuery request, CancellationToken cancellationToken)
    {
        var mechanic = await _repository.GetByIdAsync(request.Id, cancellationToken);
        return _mapper.Map<MechanicDto>(mechanic);
    }
}