using AutoMapper;
using Inside.StoreManagement.Application.Features.Orders.DTOs;
using Inside.StoreManagement.Domain.Contracts;
using Inside.StoreManagement.Domain.Entities;
using MediatR;

namespace Inside.StoreManagement.Application.Features.Orders.Queries.Handlers
{
    public class GetOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper) : IRequestHandler<GetOrderQuery, OrderWithProductsDTO>
    {
        public async Task<OrderWithProductsDTO> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            Order order = await orderRepository.GetByIdAsync(request.OrderId);

            return mapper.Map<OrderWithProductsDTO>(order);
        }
    }
}