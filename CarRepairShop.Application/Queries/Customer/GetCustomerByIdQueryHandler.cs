using AutoMapper;
using CarRepairShop.Application.DTOs.Customer;
using CarRepairShop.Domain.Aggregates.CustomerAggregate;
using CarRepairShop.Domain.Interfaces;
using MediatR;

namespace CarRepairShop.Application.Queries.Customer;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
{
    private readonly IGenericRepository<CustomerEntity> _repository;
    private readonly IMapper _mapper;

    public GetCustomerByIdQueryHandler(IGenericRepository<CustomerEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(request.Id,cancellationToken);
        return _mapper.Map<CustomerDto>(customer);
    }
}