using AutoMapper;
using CarRepairShop.Application.DTOs.Customer;
using CarRepairShop.Application.Queries.Customer;
using CarRepairShop.Domain.Aggregates.CustomerAggregate;
using CarRepairShop.Domain.Interfaces;
using CarRepairShop.Domain.ValueObjects;
using Moq;

namespace CarRepairShop.Tests.UnitTests.Customer.Queries;

[TestFixture]
public class GetCustomerByIdQueryHandlerTests
{
    private GetCustomerByIdQueryHandler _handler;
    private Mock<IGenericRepository<CustomerEntity>> _repositoryMock;
    private Mock<IMapper> _mapperMock;

    [SetUp]
    public void Setup()
    {
        _repositoryMock = new Mock<IGenericRepository<CustomerEntity>>();
        _mapperMock = new Mock<IMapper>();
        _handler = new GetCustomerByIdQueryHandler(_repositoryMock.Object,_mapperMock.Object);
    }
    
    [Test]
    public async Task Handle_ShouldReturnMappedCustomer_WhenCustomerExists()
    {
        // Arrange
        var customerId = Guid.NewGuid();
        var fullName = new FullName("John", "Doe");
        var customerEntity = new CustomerEntity(fullName,"123456789");
        var customerDto = new CustomerDto { Id = customerId, FullName = "John Doe",PhoneNumber = "123456789"};

        _repositoryMock
            .Setup(r => r.GetByIdAsync(customerId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(customerEntity);

        _mapperMock
            .Setup(m => m.Map<CustomerDto>(customerEntity))
            .Returns(customerDto);

        var query = new GetCustomerByIdQuery(customerId);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.That(result,Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(customerId));
            Assert.That(result.FullName, Is.EqualTo("John Doe"));
        });

        _repositoryMock.Verify(r => r.GetByIdAsync(customerId, It.IsAny<CancellationToken>()), Times.Once);
        _mapperMock.Verify(m => m.Map<CustomerDto>(customerEntity), Times.Once);
    }
    
        [Test]
    public async Task Handle_ShouldReturnNull_WhenCustomerDoesNotExist()
    {
        // Arrange
        var customerId = Guid.NewGuid();

        _repositoryMock
            .Setup(r => r.GetByIdAsync(customerId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((CustomerEntity)null);

        _mapperMock
            .Setup(m => m.Map<CustomerDto>(null))
            .Returns((CustomerDto)null);

        var query = new GetCustomerByIdQuery(customerId);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.That(result, Is.Null);
        _repositoryMock.Verify(r => r.GetByIdAsync(customerId, It.IsAny<CancellationToken>()), Times.Once);
        _mapperMock.Verify(m => m.Map<CustomerDto>(null), Times.Once);
    }

    [Test]
    public async Task Handle_ShouldPassCancellationToken_ToRepository()
    {
        // Arrange
        var customerId = Guid.NewGuid();
        var fullName = new FullName("Jane", "Smith");
        var entity = new CustomerEntity(fullName, "987654321");
        var dto = new CustomerDto { Id = customerId, FullName = "Jane Smith", PhoneNumber = "987654321" };

        var token = new CancellationTokenSource().Token;

        _repositoryMock
            .Setup(r => r.GetByIdAsync(customerId, token))
            .ReturnsAsync(entity);

        _mapperMock
            .Setup(m => m.Map<CustomerDto>(entity))
            .Returns(dto);

        var query = new GetCustomerByIdQuery(customerId);

        // Act
        var result = await _handler.Handle(query, token);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(customerId));
            Assert.That(result.FullName, Is.EqualTo("Jane Smith"));
            Assert.That(result.PhoneNumber, Is.EqualTo("987654321"));
        });

        _repositoryMock.Verify(r => r.GetByIdAsync(customerId, token), Times.Once);
        _mapperMock.Verify(m => m.Map<CustomerDto>(entity), Times.Once);
    }
}