using Inside.StoreManagement.Domain.Entities;

namespace Inside.StoreManagement.Domain.Contracts
{
    public interface IOrderRepository
    {
        Task<List<Order>> ListAsync(int pageNumber, int pageSize, bool? isClosed);

        Task<Order> GetByIdAsync(Guid orderId);

        Task AddAsync(Order order);
        Task UpdateAsync(Order order);

        Task<int> CountAsync(bool? isClosed);

        Task<bool> OrderIsNotClosed(Guid orderId);
    }
}
