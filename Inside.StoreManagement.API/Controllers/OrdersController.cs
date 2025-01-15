using Inside.StoreManagement.Application.Features.Orders.Commands;
using Inside.StoreManagement.Application.Features.Orders.Queries;
using Inside.StoreManagement.Application.Features.Orders.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inside.StoreManagement.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> ListOrders([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] bool? isClosed = null)
        {
            var listOrdersQuery = new ListOrdersQuery(pageNumber, pageSize, isClosed);
            var paginatedResult = await _mediator.Send(listOrdersQuery);
            return Ok(paginatedResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(Guid id)
        {
            GetOrderQuery getOrderQuery = new() { OrderId = id };

            OrderWithProductsDTO orderWithProductsDTO = await _mediator.Send(getOrderQuery);

            return Ok(orderWithProductsDTO);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            Guid orderId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetOrder), new { id = orderId }, orderId);
        }

        [HttpPost("add-product-to-order")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductToOrderCommand addProductToOrderCommand)
        {
            await _mediator.Send(addProductToOrderCommand);
            return NoContent();
        }

        [HttpDelete("remove-product-from-order")]
        public async Task<IActionResult> RemoveProduct([FromBody] RemoveProductFromOrderCommand removeProductFromOrderCommand)
        {
            await _mediator.Send(removeProductFromOrderCommand);
            return NoContent();
        }

        [HttpPost("{id}/close")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CloseOrder(Guid id)
        {
            CloseOrderCommand command = new(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}