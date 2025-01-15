using Inside.StoreManagement.Application.Features.Orders.Commands.Handlers;
using Inside.StoreManagement.Application.Features.Orders.Commands;
using Inside.StoreManagement.Domain.Contracts;
using Moq;
using Xunit;
using Inside.StoreManagement.Domain.Entities;

namespace Inside.StoreManagement.Application.Tests.UnitTests.Orders
{
    public class CreateOrderCommandHandlerTests
    {
        private readonly Mock<IOrderRepository> _orderRepositoryMock = new();
        private readonly CreateOrderCommandHandler _handler;

        public CreateOrderCommandHandlerTests()
        {
            _handler = new CreateOrderCommandHandler(_orderRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateOrder()
        {
            // Arrange
            CreateOrderCommand command = new("Carmélia");

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _orderRepositoryMock.Verify(x => x.AddAsync(It.Is<Order>(o => o.CustomerName == command.CustomerName)), Times.Once);
        }
    } 
}
