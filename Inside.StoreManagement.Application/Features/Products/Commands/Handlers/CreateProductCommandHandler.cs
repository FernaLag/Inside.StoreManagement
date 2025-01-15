using Inside.StoreManagement.Domain.Contracts;
using Inside.StoreManagement.Domain.Entities;
using MediatR;

namespace Inside.StoreManagement.Application.Features.Products.Commands.Handlers
{
    public class CreateProductCommandHandler(IProductRepository productRepository) : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new(request.Name, request.Price);

            await _productRepository.AddAsync(product);

            return product.Id;
        }   
    }
}