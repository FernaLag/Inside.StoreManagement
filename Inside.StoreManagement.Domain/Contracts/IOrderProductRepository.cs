using Inside.StoreManagement.Domain.Entities;

namespace Inside.StoreManagement.Domain.Contracts
{
    public interface IOrderProductRepository
    {
        Task<OrderProduct> GetByIdAsync(Guid orderId, Guid productId);
        Task AddAsync(OrderProduct orderProduct);
        Task RemoveAsync(OrderProduct orderProduct);
        Task<bool> NotExists(Guid orderId, Guid productId);
    }
}
