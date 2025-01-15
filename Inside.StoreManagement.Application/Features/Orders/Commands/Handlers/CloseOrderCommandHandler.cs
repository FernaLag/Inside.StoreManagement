using Inside.StoreManagement.Domain.Contracts;
using Inside.StoreManagement.Domain.Entities;
using MediatR;

namespace Inside.StoreManagement.Application.Features.Orders.Commands.Handlers
{
    public class CloseOrderCommandHandler(IOrderRepository orderRepository) : IRequestHandler<CloseOrderCommand>
    {
        private readonly IOrderRepository _orderRepository = orderRepository;

        public async Task Handle(CloseOrderCommand request, CancellationToken cancellationToken)
        {
            Order order = await _orderRepository.GetByIdAsync(request.OrderId);

            order.IsClosed = true;

            await _orderRepository.UpdateAsync(order);
        }
    }
}