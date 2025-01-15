using Inside.StoreManagement.Domain.Entities.Common;

namespace Inside.StoreManagement.Domain.Entities
{
    public class Order(string customerName) : BaseEntity
    {
        public string CustomerName { get; set; } = customerName;
        public bool IsClosed { get; set; } = false;
        public ICollection<OrderProduct> OrderProducts { get; set; } = [];
    }
}
