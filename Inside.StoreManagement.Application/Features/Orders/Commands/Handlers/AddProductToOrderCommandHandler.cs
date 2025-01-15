using Inside.StoreManagement.Domain.Contracts;
using Inside.StoreManagement.Domain.Entities;
using MediatR;

namespace Inside.StoreManagement.Application.Features.Orders.Commands.Handlers
{
    public class AddProductToOrderCommandHandler(IOrderProductRepository orderProductRepository) : IRequestHandler<AddProductToOrderCommand>
    {
        public async Task Handle(AddProductToOrderCommand request, CancellationToken cancellationToken)
        {
            OrderProduct orderProduct = new(request.OrderId, request.ProductId);

            await orderProductRepository.AddAsync(orderProduct);
        }
    }
}