using Inside.StoreManagement.Application.Features.Products.Commands;
using Inside.StoreManagement.Application.Features.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inside.StoreManagement.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductCommand command)
        {
            Guid productId = await _mediator.Send(command);
            return Ok(productId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> ListProducts()
        {
            var products = await _mediator.Send(new ListProductsQuery());
            return Ok(products);
        }
    }
}