using MediatR;
using System.Text.Json.Serialization;

namespace Inside.StoreManagement.Application.Features.Orders.Commands
{
    [method: JsonConstructor]
    public class CreateOrderCommand(string customerName) : IRequest<Guid>
    {
        public string CustomerName { get; set; } = customerName;
    }
}