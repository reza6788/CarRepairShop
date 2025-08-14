using CarRepairShop.Application.Interfaces;
using CarRepairShop.Domain.Entities;
using CarRepairShop.Domain.Interfaces;
using MediatR;

namespace CarRepairShop.Application.Commands.Customer;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
{
    private readonly IGenericRepository<CustomerEntity> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCustomerCommandHandler(IGenericRepository<CustomerEntity> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(request.Customer.Id, cancellationToken);
        if (customer == null) throw new Exception("Customer not found");

        customer.MarkAsDeleted();

        _repository.Update(customer);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}