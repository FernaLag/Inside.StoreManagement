using Inside.StoreManagement.Domain.Contracts;
using Inside.StoreManagement.Domain.Entities;
using MediatR;

namespace Inside.StoreManagement.Application.Features.Orders.Commands.Handlers
{
    public class RemoveProductFromOrderCommandHandler(IOrderProductRepository orderProductRepository) : IRequestHandler<RemoveProductFromOrderCommand>
    {
        public async Task Handle(RemoveProductFromOrderCommand request, CancellationToken cancellationToken)
        {
            OrderProduct orderProduct = await orderProductRepository.GetByIdAsync(request.OrderId, request.ProductId);

            await orderProductRepository.RemoveAsync(orderProduct);
        }
    }
}