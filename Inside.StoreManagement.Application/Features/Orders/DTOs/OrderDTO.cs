using Inside.StoreManagement.Application.Features.Products.DTOs;

namespace Inside.StoreManagement.Application.Features.Orders.DTOs
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public bool IsClosed { get; set; }
    }

    public class OrderWithProductsDTO : OrderDTO
    {
        public List<ProductDTO> Products { get; set; } = [];
    }
}