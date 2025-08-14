using CarRepairShop.Application.Interfaces;
using CarRepairShop.Domain.Entities;
using CarRepairShop.Domain.Interfaces;
using CarRepairShop.Domain.ValueObjects;
using MediatR;

namespace CarRepairShop.Application.Commands.Customer;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
{
    private readonly IGenericRepository<CustomerEntity> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCustomerCommandHandler(IGenericRepository<CustomerEntity> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(request.Customer.Id, cancellationToken);
        if (customer == null) throw new Exception("Customer not found");

        var fullName = new FullName(request.Customer.FirstName, request.Customer.LastName);
        customer.UpdateName(fullName);
        customer.UpdatePhoneNumber(request.Customer.PhoneNumber);

        customer.MarkAsUpdated();
        _repository.Update(customer);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
    
}