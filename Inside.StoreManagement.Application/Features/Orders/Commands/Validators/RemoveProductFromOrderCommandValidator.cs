using FluentValidation;
using Inside.StoreManagement.Domain.Contracts;

namespace Inside.StoreManagement.Application.Features.Orders.Commands.Validators
{
    public class RemoveProductFromOrderCommandValidator : AbstractValidator<RemoveProductFromOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public RemoveProductFromOrderCommandValidator(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;

            RuleFor(command => command.OrderId)
                .NotEmpty().WithMessage("OrderId cannot be empty.");

            RuleFor(command => command.ProductId)
                .NotEmpty().WithMessage("ProductId cannot be empty.");

            RuleFor(command => command.OrderId)
                .MustAsync(async (orderId, cancellation) => await _orderRepository.OrderIsNotClosed(orderId))
                .WithMessage("Cannot remove products from a closed order.");
        }
    }
}