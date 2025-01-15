using MediatR;

namespace Inside.StoreManagement.Application.Features.Orders.Commands
{
    public class CloseOrderCommand(Guid orderId) : IRequest
    {
        public Guid OrderId { get; } = orderId;
    }
}