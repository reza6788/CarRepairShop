using CarRepairShop.Application.DTOs.Customer;
using MediatR;

namespace CarRepairShop.Application.Commands.Customer;

public record UpdateCustomerCommand(CustomerUpdateDto Customer) : IRequest;