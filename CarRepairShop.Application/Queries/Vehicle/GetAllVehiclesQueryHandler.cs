using AutoMapper;
using CarRepairShop.Application.DTOs.Vehicle;
using CarRepairShop.Domain.Entities;
using CarRepairShop.Domain.Interfaces;
using MediatR;

namespace CarRepairShop.Application.Queries.Vehicle;

public class GetAllVehiclesQueryHandler : IRequestHandler<GetAllVehiclesQuery, IEnumerable<VehicleDto>>
{
    private readonly IGenericRepository<VehicleEntity> _repository;
    private readonly IMapper _mapper;

    public GetAllVehiclesQueryHandler(IGenericRepository<VehicleEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<VehicleDto>> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
    {
        var vehicles = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<VehicleDto>>(vehicles);
    }
}