using FluentValidation;
using Inside.StoreManagement.Domain.Contracts;

namespace Inside.StoreManagement.Application.Features.Orders.Commands.Validators
{
    public class AddProductToOrderCommandValidator : AbstractValidator<AddProductToOrderCommand>
    {
        public AddProductToOrderCommandValidator(IOrderRepository orderRepository, IOrderProductRepository orderProductRepository)
        {
            RuleFor(command => command.OrderId)
                .NotEmpty().WithMessage("OrderId cannot be empty.");

            RuleFor(command => command.ProductId)
                .NotEmpty().WithMessage("ProductId cannot be empty.");

            RuleFor(command => command.OrderId)
                .MustAsync(async (orderId, cancellation) => await orderRepository.OrderIsNotClosed(orderId))
                .WithMessage("Cannot add products to a closed order.");

            RuleFor(command => command)
                .MustAsync(async (command, cancellation) =>
                    await orderProductRepository.NotExists(command.OrderId, command.ProductId))
                .WithMessage("The product is already added to this order.");
        }
    }
}