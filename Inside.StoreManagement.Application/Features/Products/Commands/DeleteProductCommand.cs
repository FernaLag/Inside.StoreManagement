using MediatR;

namespace Inside.StoreManagement.Application.Features.Products.Commands
{
    public class DeleteProductCommand(Guid productId) : IRequest
    {
        public Guid ProductId { get; } = productId;
    }
}