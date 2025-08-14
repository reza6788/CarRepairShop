using AutoMapper;
using CarRepairShop.Application.DTOs.Vehicle;
using CarRepairShop.Domain.Entities;
using CarRepairShop.Domain.Interfaces;
using MediatR;

namespace CarRepairShop.Application.Queries.Vehicle;

public class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, VehicleDto>
{
    private readonly IGenericRepository<VehicleEntity> _repository;
    private readonly IMapper _mapper;

    public GetVehicleByIdQueryHandler(IGenericRepository<VehicleEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<VehicleDto> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
    {
        var vehicle = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<VehicleDto>(vehicle);
    }
}