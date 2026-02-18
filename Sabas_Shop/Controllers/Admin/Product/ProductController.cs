using Application.Handlers.Admin.Product.Comands.Create;
using Application.Handlers.Admin.Product.Comands.Delete;
using Application.Handlers.Admin.Product.Comands.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sabas_Shop.Settings;

namespace Sabas_Shop.Controllers.Admin.Product
{
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductController : ApiControllerBase
    {
        public ProductController(ISender sender) : base(sender) { }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command, CancellationToken ct)
        {
            var id = await Sender.Send(command, ct);
            return Ok(new { id });
           
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand command, CancellationToken ct)
        {
            if ( command.Id <= 0)
                return BadRequest("Route id must match body id.");

            var updatedId = await Sender.Send(command, ct);
            return Ok(new { id = updatedId });
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery]int id, CancellationToken ct)
        {
            await Sender.Send(new DeleteProductCommand(id), ct);
            return NoContent();
        }
    }
}
