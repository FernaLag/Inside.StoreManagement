using Inside.StoreManagement.Domain.Contracts;
using Inside.StoreManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inside.StoreManagement.Persistence.Repositories
{
    public class OrderProductRepository(OrdersDbContext context) : IOrderProductRepository
    {
        private readonly OrdersDbContext _context = context;

        public async Task<OrderProduct> GetByIdAsync(Guid orderId, Guid productId)
        {
            return await _context.OrderProducts
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(o => o.OrderId == orderId && o.ProductId == productId);
        }

        public async Task AddAsync(OrderProduct orderProduct)
        {
            await _context.OrderProducts.AddAsync(orderProduct);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(OrderProduct orderProduct)
        {
            _context.OrderProducts.Remove(orderProduct);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> NotExists(Guid orderId, Guid productId)
        {
            var orderProduct = await GetByIdAsync(orderId, productId);

            return orderProduct == null;
        }
    }
}
