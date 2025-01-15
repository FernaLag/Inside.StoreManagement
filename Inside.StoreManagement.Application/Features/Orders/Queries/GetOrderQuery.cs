using Inside.StoreManagement.Application.Features.Orders.DTOs;
using MediatR;

namespace Inside.StoreManagement.Application.Features.Orders.Queries
{
    public class GetOrderQuery : IRequest<OrderWithProductsDTO>
    {
        public Guid OrderId { get; set; }
    }
}