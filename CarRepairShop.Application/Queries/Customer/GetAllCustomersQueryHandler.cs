using AutoMapper;
using CarRepairShop.Application.DTOs.Customer;
using CarRepairShop.Domain.Interfaces;
using MediatR;

namespace CarRepairShop.Application.Queries.Customer;

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerDto>>
{
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public GetAllCustomersQueryHandler(ICustomerRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = await _repository.GetAllWithVehiclesAsync(cancellationToken);
        return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        // var result = customers.Select(customerEntity => new CustomerDto
        //     {
        //         Id = customerEntity.Id,
        //         FullName = customerEntity.Name,
        //         PhoneNumber = customerEntity.PhoneNumber,
        //         Vehicles = customerEntity.Vehicles.Select(x => new VehicleSummaryDto
        //             {
        //                 Id = x.Id,
        //                 Make = x.Make,
        //                 LicensePlateNumber = x.LicensePlate.Value,
        //                 Model = x.Model,
        //                 Year = x.Year
        //             })
        //             .ToList()
        //     })
        //     .ToList();
        // return result;
    }
}