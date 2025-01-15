using Inside.StoreManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Inside.StoreManagement.Persistence.Seeders
{
    public static class DatabaseInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<OrdersDbContext>();

            context.Database.Migrate();

            if (!context.Orders.Any())
                SeedDatabase(context);
        }

        public static void SeedDatabase(OrdersDbContext context)
        {
            Guid firstOrderGuid = Guid.NewGuid();
            Guid firstProductGuid = Guid.NewGuid();

            List<Order> orders =
            [
                new("João") { Id = firstOrderGuid, IsClosed = true },
                new("Maria") { Id = Guid.NewGuid(), IsClosed = false },
                new("Carla") { Id = Guid.NewGuid(), IsClosed = false },
                new("Agnaldo") { Id = Guid.NewGuid(), IsClosed = false }
            ];

            List<Product> products =
            [
                new("Banana", 10) { Id = firstProductGuid },
                new("Carro", 20000) { Id = Guid.NewGuid() },
                new("Tomate", 4) { Id = Guid.NewGuid() },
                new("Alface", 2) { Id = Guid.NewGuid() }
            ];

            context.Orders.AddRange(orders);
            context.Products.AddRange(products);
            context.OrderProducts.Add(new OrderProduct(firstOrderGuid, firstProductGuid));

            context.SaveChanges();
        }
    }
}
