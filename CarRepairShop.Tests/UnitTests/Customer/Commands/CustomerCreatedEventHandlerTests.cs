using CarRepairShop.Application.Commands.Customer;
using CarRepairShop.Application.DTOs.Customer;
using CarRepairShop.Application.Interfaces;
using CarRepairShop.Domain.Aggregates.CustomerAggregate;
using CarRepairShop.Domain.Events.Customer;
using CarRepairShop.Domain.Interfaces;
using MediatR;
using Moq;

namespace CarRepairShop.Tests.UnitTests.Customer.Commands;

[TestFixture]
public class CustomerCreatedEventHandlerTests
{
    private Mock<IGenericRepository<CustomerEntity>> _repositoryMock = null!;
    private Mock<IUnitOfWork> _unitOfWorkMock = null!;
    private Mock<IMediator> _mediatorMock = null!;
    private CreateCustomerCommandHandler _handler = null!;
    
    [SetUp]
    public void Setup()
    {
        _repositoryMock = new Mock<IGenericRepository<CustomerEntity>>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _mediatorMock = new Mock<IMediator>();

        _handler = new CreateCustomerCommandHandler(
            _repositoryMock.Object,
            _unitOfWorkMock.Object,
            _mediatorMock.Object
        );
    }
    
    [Test]
    public async Task Handle_ShouldAddCustomer_SaveChanges_AndPublishEvent()
    {
        var command = new CreateCustomerCommand(new CustomerCreateDto
        {
            FirstName = "John",
            LastName = "Doe",
            PhoneNumber = "123456789"
        });

        var result = await _handler.Handle(command, CancellationToken.None);

        _repositoryMock.Verify(r => r.AddAsync(It.IsAny<CustomerEntity>(), It.IsAny<CancellationToken>()), Times.Once);
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        _mediatorMock.Verify(m => m.Publish(It.IsAny<INotification>(), It.IsAny<CancellationToken>()), Times.Once);

        Assert.That(result, Is.Not.EqualTo(Guid.Empty));
    }
    
    [Test]
    public async Task Handle_ShouldCallSaveChanges()
    {
        var repositoryMock = new Mock<IGenericRepository<CustomerEntity>>();
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var mediatorMock = new Mock<IMediator>();

        var handler = new CreateCustomerCommandHandler(repositoryMock.Object, unitOfWorkMock.Object, mediatorMock.Object);

        var command = new CreateCustomerCommand(new CustomerCreateDto()
        {
            FirstName = "Jane",
            LastName = "Smith",
            PhoneNumber = "67890"
        });

        await handler.Handle(command, CancellationToken.None);

        unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
    
    [Test]
    public async Task Handle_ShouldPublishCustomerCreatedEvent()
    {
        var repositoryMock = new Mock<IGenericRepository<CustomerEntity>>();
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var mediatorMock = new Mock<IMediator>();

        var handler = new CreateCustomerCommandHandler(repositoryMock.Object, unitOfWorkMock.Object, mediatorMock.Object);

        var command = new CreateCustomerCommand(new CustomerCreateDto
        {
            FirstName = "Mike",
            LastName = "Taylor",
            PhoneNumber = "99999"
        });

        var result = await handler.Handle(command, CancellationToken.None);

        mediatorMock.Verify(m => m.Publish(
            It.Is<CreateCustomerEvent>(e =>
                e.CustomerId == result &&
                e.FullName == "Mike Taylor"),
            It.IsAny<CancellationToken>()), Times.Once);
    }
    
    [Test]
    public async Task Handle_ShouldReturnCustomerId()
    {
        var repositoryMock = new Mock<IGenericRepository<CustomerEntity>>();
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var mediatorMock = new Mock<IMediator>();

        var handler = new CreateCustomerCommandHandler(repositoryMock.Object, unitOfWorkMock.Object, mediatorMock.Object);

        var command = new CreateCustomerCommand(new CustomerCreateDto
        {
            FirstName = "Alex",
            LastName = "Brown",
            PhoneNumber = "11111"
        });

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.That(result, Is.Not.EqualTo(Guid.Empty));
    }
    
    [Test]
    public void Handle_ShouldThrowException_WhenRepositoryFails()
    {
        var repositoryMock = new Mock<IGenericRepository<CustomerEntity>>();
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var mediatorMock = new Mock<IMediator>();

        repositoryMock.Setup(r => r.AddAsync(It.IsAny<CustomerEntity>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception("DB error"));

        var handler = new CreateCustomerCommandHandler(repositoryMock.Object, unitOfWorkMock.Object, mediatorMock.Object);

        var command = new CreateCustomerCommand(new CustomerCreateDto
        {
            FirstName = "Test",
            LastName = "Fail",
            PhoneNumber = "00000"
        });

        Assert.ThrowsAsync<Exception>(() => handler.Handle(command, CancellationToken.None));
    }
}