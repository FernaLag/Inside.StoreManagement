using Xunit;
using Moq;
using Inside.StoreManagement.Application.Features.Orders.Commands;
using Inside.StoreManagement.Application.Features.Orders.Commands.Handlers;
using Inside.StoreManagement.Domain.Contracts;
using Inside.StoreManagement.Domain.Entities;

namespace Inside.StoreManagement.Application.Tests.UnitTests.Orders
{
    public class AddProductToOrderCommandHandlerTests
    {
        private readonly Mock<IOrderProductRepository> _orderProductRepositoryMock = new();
        private readonly AddProductToOrderCommandHandler _handler;

        public AddProductToOrderCommandHandlerTests()
        {
            _handler = new AddProductToOrderCommandHandler(_orderProductRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldAddProductToOrder()
        {
            // Arrange
            AddProductToOrderCommand command = new(Guid.NewGuid(), Guid.NewGuid());

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _orderProductRepositoryMock.Verify(x => x.AddAsync(It.IsAny<OrderProduct>()), Times.Once);
        }
    }
}