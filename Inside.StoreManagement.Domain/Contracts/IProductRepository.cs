using Inside.StoreManagement.Domain.Entities;

namespace Inside.StoreManagement.Domain.Contracts
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task DeleteAsync(Guid productId);
        Task<List<Product>> GetAllAsync();
        Task<bool> ProductNotLinkedToAnyOrder(Guid productId, CancellationToken cancellationToken);
    }
}