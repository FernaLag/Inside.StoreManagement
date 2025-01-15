namespace Inside.StoreManagement.Domain.Entities
{
    public class OrderProduct(Guid orderId, Guid productId)
    {
        public Guid OrderId { get; set; } = orderId;
        public Order Order { get; set; }

        public Guid ProductId { get; set; } = productId;
        public Product Product { get; set; }
    }
}