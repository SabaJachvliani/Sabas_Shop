using Application.Handlers.Admin.Product.Comands.Create;
using Application.Handlers.Admin.Product.Comands.Delete;
using Application.Handlers.Admin.Product.Comands.Update;
using Application.Handlers.Admin.Product.Queries.GetProductById;
using Application.Handlers.Admin.Product.Queries.GetProductList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sabas_Shop.Settings;

namespace Sabas_Shop.Controllers.Admin.Product
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductController : ApiControllerBase
    {
        public ProductController(ISender sender) : base(sender) { }
        
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command, CancellationToken ct)
        {
            var id = await Sender.Send(command, ct);
            return Ok(id);
           
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] UpdateProductCommand command, CancellationToken ct)
        {
            
            var updatedId = Sender.Send(command, ct);
            return (IActionResult)updatedId;
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery]int id, CancellationToken ct)
        {
            await Sender.Send(new DeleteProductCommand(id), ct);
            return NoContent();
        }

        [HttpGet("GetProductList")]
        public async Task<IActionResult> Get( CancellationToken ct)
        {
            var productList = await Sender.Send(new GetProductListQuery(), ct);
            return Ok(productList);
        }

        [HttpGet("GetProductById")]
        public async Task<IActionResult> Get([FromQuery]int id, CancellationToken ct)
        {
            var productById = await Sender.Send(new GetProductByIdQuery(id), ct);
            return Ok(productById);
        }


    }   
}
