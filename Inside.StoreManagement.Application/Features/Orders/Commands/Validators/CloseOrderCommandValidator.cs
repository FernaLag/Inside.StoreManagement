using FluentValidation;
using Inside.StoreManagement.Domain.Contracts;
using Inside.StoreManagement.Domain.Entities;

namespace Inside.StoreManagement.Application.Features.Orders.Commands.Validators
{
    public class CloseOrderCommandValidator : AbstractValidator<CloseOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public CloseOrderCommandValidator(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;

            RuleFor(command => command.OrderId)
                .NotEmpty()
                .WithMessage("OrderId cannot be empty.")
                .MustAsync(async (orderId, cancellationToken) =>
                    await orderRepository.GetByIdAsync(orderId) != null)
                .WithMessage("Order not found.")
                .DependentRules(() =>
                {
                    RuleFor(command => command.OrderId)
                        .MustAsync(OrderHasProducts)
                        .WithMessage("Order must have at least one product to be closed.");
                });
        }

        private async Task<bool> OrderHasProducts(Guid orderId, CancellationToken cancellationToken)
        {
            Order order = await _orderRepository.GetByIdAsync(orderId);
            return order != null && order.OrderProducts.Count != 0;
        }
    }
}