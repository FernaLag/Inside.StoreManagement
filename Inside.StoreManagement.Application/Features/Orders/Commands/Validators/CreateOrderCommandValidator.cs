using FluentValidation;

namespace Inside.StoreManagement.Application.Features.Orders.Commands.Validators
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(order => order.CustomerName)
                .NotEmpty()
                .WithMessage("Customer name cannot be empty.");
        }
    }
}
