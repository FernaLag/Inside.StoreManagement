using Inside.StoreManagement.Domain.Entities;
using Inside.StoreManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Shouldly;
using Inside.StoreManagement.Persistence.Seeders;

namespace Inside.StoreManagement.Persistence.Tests.IntegrationTests
{
    public class OrderRepositoryIntegrationTests
    {
        private readonly StoreManagementDbContext _context;
        private readonly OrderRepository _repository;

        public OrderRepositoryIntegrationTests()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<StoreManagementDbContext>()
                .UseSqlServer("Server=(local)\\SQLEXPRESS;Database=TestStoreManagementDB;Trusted_Connection=True;TrustServerCertificate=True")
                .Options;

            _context = new StoreManagementDbContext(options);

            _context.Database.EnsureDeleted();
            _context.Database.Migrate();

            DatabaseInitializer.SeedDatabase(_context);

            _repository = new OrderRepository(_context);
        }

        [Fact]
        public async Task AddAsync_ShouldAddOrder()
        {
            // Arrange
            Order order = new("Ayrton");

            // Act
            await _repository.AddAsync(order);
            Order result = await _repository.GetByIdAsync(order.Id);

            // Assert
            result.ShouldNotBeNull();
            result.CustomerName.ShouldBe("Ayrton");
        }

        [Fact]
        public async Task UpdateAsync_ShouldCloseOrder()
        {
            // Arrange
            Order order = await _context.Orders.FirstOrDefaultAsync(o => !o.IsClosed);
            order.IsClosed = true;

            // Act
            await _repository.UpdateAsync(order);

            // Assert
            Order updatedOrder = await _repository.GetByIdAsync(order.Id);
            updatedOrder.IsClosed.ShouldBeTrue();
        }

        [Theory]
        [InlineData(null, 4)]
        [InlineData(true, 1)]
        [InlineData(false, 3)]
        public async Task ListAsync_ShouldReturnAllOrders(bool? isClosed, int ordersCount)
        {
            // Act
            List<Order> orders = await _repository.ListAsync(1, 10, isClosed);

            // Assert
            orders.ShouldNotBeEmpty();
            orders.Count.ShouldBe(ordersCount);
        }
    }
}
