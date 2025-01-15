using Inside.StoreManagement.Domain.Contracts;
using MediatR;

namespace Inside.StoreManagement.Application.Features.Products.Commands.Handlers
{
    public class RemoveProductCommandHandler(IProductRepository productRepository) : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.DeleteAsync(request.ProductId);
        }
    }
}