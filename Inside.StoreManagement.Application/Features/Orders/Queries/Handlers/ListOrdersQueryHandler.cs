using AutoMapper;
using Inside.StoreManagement.Application.Features.Orders.DTOs;
using Inside.StoreManagement.Application.Helpers;
using Inside.StoreManagement.Domain.Contracts;
using Inside.StoreManagement.Domain.Entities;
using MediatR;

namespace Inside.StoreManagement.Application.Features.Orders.Queries.Handlers
{
    public class ListOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper) : IRequestHandler<ListOrdersQuery, PaginatedResult<OrderDTO>>
    {
        public async Task<PaginatedResult<OrderDTO>> Handle(ListOrdersQuery request, CancellationToken cancellationToken)
        {
            List<Order> orders = await orderRepository.ListAsync(request.PageNumber, request.PageSize, request.IsClosed);
            int totalOrdersCount = await orderRepository.CountAsync(request.IsClosed);

            List<OrderDTO> ordersDTO = mapper.Map<List<OrderDTO>>(orders);

            return new PaginatedResult<OrderDTO>(ordersDTO, totalOrdersCount, request.PageNumber, request.PageSize);
        }
    }
}