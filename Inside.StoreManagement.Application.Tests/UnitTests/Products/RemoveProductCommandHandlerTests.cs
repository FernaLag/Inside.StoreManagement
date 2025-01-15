using Inside.StoreManagement.Application.Features.Products.Commands.Handlers;
using Inside.StoreManagement.Application.Features.Products.Commands;
using Inside.StoreManagement.Domain.Contracts;
using Moq;
using Xunit;

namespace Inside.StoreManagement.Application.Tests.UnitTests.Products
{
    public class RemoveProductCommandHandlerTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock = new();
        private readonly RemoveProductCommandHandler _handler;

        public RemoveProductCommandHandlerTests()
        {
            _handler = new RemoveProductCommandHandler(_productRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldRemoveProduct()
        {
            // Arrange
            DeleteProductCommand command = new(Guid.NewGuid());

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _productRepositoryMock.Verify(x => x.DeleteAsync(command.ProductId), Times.Once);
        }
    }
}
