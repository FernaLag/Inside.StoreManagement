using Inside.StoreManagement.Application.Features.Orders.DTOs;
using Inside.StoreManagement.Application.Helpers;
using MediatR;

namespace Inside.StoreManagement.Application.Features.Orders.Queries
{
    public class ListOrdersQuery(int pageNumber, int pageSize, bool? isClosed = null) : IRequest<PaginatedResult<OrderDTO>>
    {
        public int PageNumber { get; set; } = pageNumber;
        public int PageSize { get; set; } = pageSize;
        public bool? IsClosed { get; set; } = isClosed;
    }
}