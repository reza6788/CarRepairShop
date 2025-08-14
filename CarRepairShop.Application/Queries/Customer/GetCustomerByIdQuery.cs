using CarRepairShop.Application.DTOs.Customer;
using MediatR;

namespace CarRepairShop.Application.Queries.Customer;

public record GetCustomerByIdQuery(Guid Id) : IRequest<CustomerDto>;