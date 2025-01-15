using MediatR;

namespace Inside.StoreManagement.Application.Features.Orders.Commands
{
    public class RemoveProductFromOrderCommand(Guid orderId, Guid productId) : IRequest
    {
        public Guid OrderId { get; set; } = orderId;
        public Guid ProductId { get; set; } = productId;
    }
}