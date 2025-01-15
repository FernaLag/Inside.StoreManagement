using Inside.StoreManagement.Application.Features.Products.DTOs;
using MediatR;

namespace Inside.StoreManagement.Application.Features.Products.Queries
{
    public class ListProductsQuery : IRequest<List<ProductDTO>>
    {
    }
}