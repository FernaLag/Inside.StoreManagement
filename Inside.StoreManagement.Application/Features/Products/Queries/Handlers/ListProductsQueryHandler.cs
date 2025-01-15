using AutoMapper;
using Inside.StoreManagement.Application.Features.Products.DTOs;
using Inside.StoreManagement.Domain.Contracts;
using Inside.StoreManagement.Domain.Entities;
using MediatR;

namespace Inside.StoreManagement.Application.Features.Products.Queries.Handlers
{
    public class ListProductsQueryHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<ListProductsQuery, List<ProductDTO>>
    {
        public async Task<List<ProductDTO>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
        {
            List<Product> products = await productRepository.GetAllAsync();

            return mapper.Map<List<ProductDTO>>(products);
        }
    }
}