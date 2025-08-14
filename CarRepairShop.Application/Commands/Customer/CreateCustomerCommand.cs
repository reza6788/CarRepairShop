using CarRepairShop.Application.DTOs.Customer;
using MediatR;

namespace CarRepairShop.Application.Commands.Customer;

public record CreateCustomerCommand(CustomerCreateDto Customer) : IRequest<Guid>;