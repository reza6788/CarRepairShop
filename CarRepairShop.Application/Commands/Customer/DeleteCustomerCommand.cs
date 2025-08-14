using CarRepairShop.Application.DTOs.Customer;
using MediatR;

namespace CarRepairShop.Application.Commands.Customer;

public record DeleteCustomerCommand(CustomerDeleteDto Customer) : IRequest;