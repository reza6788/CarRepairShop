using CarRepairShop.Application.Interfaces;
using CarRepairShop.Domain.Entities;
using CarRepairShop.Domain.Interfaces;
using CarRepairShop.Domain.ValueObjects;
using MediatR;

namespace CarRepairShop.Application.Commands.Customer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
{
    private readonly IGenericRepository<CustomerEntity> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCustomerCommandHandler(IGenericRepository<CustomerEntity> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var fullName = new FullName(request.Customer.FirstName, request.Customer.LastName);
        var customer = new CustomerEntity(fullName, request.Customer.PhoneNumber);
        await _repository.AddAsync(customer, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return customer.Id;
    }
}