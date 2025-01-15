using Inside.StoreManagement.Domain.Contracts;
using Inside.StoreManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inside.StoreManagement.Persistence.Repositories
{
    public class OrderRepository(OrdersDbContext context) : IOrderRepository
    {
        private readonly OrdersDbContext _context = context;

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Order> GetByIdAsync(Guid orderId)
        {
            return await _context.Orders
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<List<Order>> ListAsync(int pageNumber, int pageSize, bool? isClosed)
        {
            var query = _context.Orders
                .Include(o => o.OrderProducts)
                .OrderBy(o => o.CreatedAt)
                .AsQueryable();

            if (isClosed.HasValue)
                query = query.Where(o => o.IsClosed.Equals(isClosed.Value));

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> CountAsync(bool? isClosed)
        {
            var query = _context.Orders.AsQueryable();

            if (isClosed.HasValue)
                query = query.Where(o => o.IsClosed.Equals(isClosed.Value));

            return await query.CountAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> OrderIsNotClosed(Guid orderId)
        {
            var order = await GetByIdAsync(orderId);
            return order != null && !order.IsClosed;
        }
    }
}
