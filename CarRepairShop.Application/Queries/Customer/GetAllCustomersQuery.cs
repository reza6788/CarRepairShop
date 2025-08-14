using CarRepairShop.Application.DTOs.Customer;
using MediatR;

namespace CarRepairShop.Application.Queries.Customer;

public record GetAllCustomersQuery() : IRequest<IEnumerable<CustomerDto>>;