using Inside.StoreManagement.Domain.Contracts;
using Inside.StoreManagement.Domain.Entities;
using MediatR;

namespace Inside.StoreManagement.Application.Features.Orders.Commands.Handlers
{
    public class CreateOrderCommandHandler(IOrderRepository orderRepository) : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository = orderRepository;

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Order order = new(request.CustomerName);

            await _orderRepository.AddAsync(order);

            return order.Id;
        }
    }
}