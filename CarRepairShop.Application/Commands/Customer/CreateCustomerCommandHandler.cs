using CarRepairShop.Application.Interfaces;
using CarRepairShop.Domain.Aggregates.CustomerAggregate;
using CarRepairShop.Domain.Events.Customer;
using CarRepairShop.Domain.Interfaces;
using CarRepairShop.Domain.ValueObjects;
using MediatR;

namespace CarRepairShop.Application.Commands.Customer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
{
    private readonly IGenericRepository<CustomerEntity> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;

    public CreateCustomerCommandHandler(IGenericRepository<CustomerEntity> repository,
        IUnitOfWork unitOfWork,
        IMediator mediator)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mediator = mediator;
    }

    public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var fullName = new FullName(request.Customer.FirstName, request.Customer.LastName);
        var customer = new CustomerEntity(fullName, request.Customer.PhoneNumber);
        await _repository.AddAsync(customer, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        await _mediator.Publish(new CreateCustomerEvent(customer.Id, fullName.FirstName + " " + fullName.LastName), cancellationToken);
        
        return customer.Id;
    }
}