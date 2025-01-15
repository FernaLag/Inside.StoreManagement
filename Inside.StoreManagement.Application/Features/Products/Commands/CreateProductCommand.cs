using MediatR;

namespace Inside.StoreManagement.Application.Features.Products.Commands
{
    public class CreateProductCommand(string name, decimal price) : IRequest<Guid>
    {
        public string Name { get; } = name;
        public decimal Price { get; } = price;
    }
}