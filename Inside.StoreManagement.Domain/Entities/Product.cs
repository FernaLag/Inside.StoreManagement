using Inside.StoreManagement.Domain.Entities.Common;

namespace Inside.StoreManagement.Domain.Entities
{
    public class Product(string name, decimal price) : BaseEntity
    {
        public string Name { get; set; } = name;
        public decimal Price { get; set; } = price;
        public ICollection<OrderProduct> OrderProducts { get; set; } = [];
    }
}