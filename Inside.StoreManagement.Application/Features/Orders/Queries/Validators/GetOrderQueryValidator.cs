using FluentValidation;
using Inside.StoreManagement.Domain.Contracts;

namespace Inside.StoreManagement.Application.Features.Orders.Queries.Validators
{
    public class GetOrderQueryValidator : AbstractValidator<GetOrderQuery>
    {
        public GetOrderQueryValidator(IOrderRepository orderRepository)
        {
            RuleFor(query => query.OrderId)
                .NotEmpty().WithMessage("OrderId cannot be empty.")
                .MustAsync(async (orderId, cancellationToken) =>
                    await orderRepository.GetByIdAsync(orderId) != null)
                .WithMessage("Order not found.");
        }
    }
}