using Inside.StoreManagement.Application.Features.Orders.Commands.Handlers;
using Inside.StoreManagement.Application.Features.Orders.Commands;
using Inside.StoreManagement.Domain.Contracts;
using Inside.StoreManagement.Domain.Entities;
using Moq;
using Xunit;

namespace Inside.StoreManagement.Application.Tests.UnitTests.Orders
{
    public class RemoveProductFromOrderCommandHandlerTests
    {
        private readonly Mock<IOrderProductRepository> _orderProductRepositoryMock = new();
        private readonly RemoveProductFromOrderCommandHandler _handler;

        public RemoveProductFromOrderCommandHandlerTests()
        {
            _handler = new RemoveProductFromOrderCommandHandler(_orderProductRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldRemoveProductFromOrder()
        {
            // Arrange
            RemoveProductFromOrderCommand command = new(Guid.NewGuid(), Guid.NewGuid());
            _orderProductRepositoryMock.Setup(x => x.GetByIdAsync(command.OrderId, command.ProductId))
                                       .ReturnsAsync(new OrderProduct(command.OrderId, command.ProductId));

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _orderProductRepositoryMock.Verify(x => x.RemoveAsync(It.IsAny<OrderProduct>()), Times.Once);
        }
    }
}
