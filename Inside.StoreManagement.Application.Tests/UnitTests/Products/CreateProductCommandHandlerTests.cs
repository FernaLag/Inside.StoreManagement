using Inside.StoreManagement.Application.Features.Products.Commands.Handlers;
using Inside.StoreManagement.Application.Features.Products.Commands;
using Inside.StoreManagement.Domain.Contracts;
using Moq;
using Xunit;
using Inside.StoreManagement.Domain.Entities;

namespace Inside.StoreManagement.Application.Tests.UnitTests.Products
{
    public class CreateProductCommandHandlerTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock = new();
        private readonly CreateProductCommandHandler _handler;

        public CreateProductCommandHandlerTests()
        {
            _handler = new CreateProductCommandHandler(_productRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateProduct()
        {
            // Arrange
            CreateProductCommand command = new("Caneta", 123.45M);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _productRepositoryMock.Verify(x => x.AddAsync(It.Is<Product>(p => p.Name == command.Name && p.Price == command.Price)), Times.Once);
        }
    }
}
