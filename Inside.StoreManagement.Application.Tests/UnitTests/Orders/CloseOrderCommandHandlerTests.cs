using Inside.StoreManagement.Application.Features.Orders.Commands.Handlers;
using Inside.StoreManagement.Application.Features.Orders.Commands;
using Inside.StoreManagement.Domain.Contracts;
using Inside.StoreManagement.Domain.Entities;
using Moq;
using Xunit;

namespace Inside.StoreManagement.Application.Tests.UnitTests.Orders
{
    public class CloseOrderCommandHandlerTests
    {
        private readonly Mock<IOrderRepository> _orderRepositoryMock = new();
        private readonly CloseOrderCommandHandler _handler;

        public CloseOrderCommandHandlerTests()
        {
            _handler = new CloseOrderCommandHandler(_orderRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldCloseOrder()
        {
            // Arrange
            CloseOrderCommand command = new(Guid.NewGuid());
            _orderRepositoryMock.Setup(x => x.GetByIdAsync(command.OrderId))
                                .ReturnsAsync(new Order("Carmélia") { Id = command.OrderId });

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _orderRepositoryMock.Verify(x => x.UpdateAsync(It.Is<Order>(o => o.Id == command.OrderId && o.IsClosed)), Times.Once);
        }
    }
}
