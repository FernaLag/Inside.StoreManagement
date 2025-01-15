using Inside.StoreManagement.Domain.Contracts;
using Inside.StoreManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inside.StoreManagement.Persistence.Repositories
{
    public class ProductRepository(OrdersDbContext context) : IProductRepository
    {
        private readonly OrdersDbContext _context = context;

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<bool> ProductNotLinkedToAnyOrder(Guid productId, CancellationToken cancellationToken)
        {
            return !await _context.OrderProducts.AnyAsync(op => op.ProductId == productId, cancellationToken);
        }
    }
}
