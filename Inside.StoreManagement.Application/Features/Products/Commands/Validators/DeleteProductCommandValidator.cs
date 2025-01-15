using FluentValidation;
using Inside.StoreManagement.Domain.Contracts;

namespace Inside.StoreManagement.Application.Features.Products.Commands.Validators
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(command => command.ProductId)
                .NotEmpty().WithMessage("Product ID cannot be empty.")
                .MustAsync(async (productId, cancellationToken) => await _productRepository.ProductNotLinkedToAnyOrder(productId, cancellationToken))
                .WithMessage("The product is linked to an order and cannot be deleted.");
        }
    }
}
