using Application.Handlers.Admin.ProductCategory.Command.Delete;
using Application.Handlers.Admin.ProductCategory.Command.Update;
using Application.Handlers.Admin.ProductCategory.Queries.GetProductCategoruById;
using Application.Handlers.Admin.ProductCategory.Queries.GetProductCategoryList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sabas_Shop.Settings;

namespace Sabas_Shop.Controllers.Admin.ProductCategory
{
    public class ProductCategoryController : ApiControllerBase
    {
        public ProductCategoryController(ISender sender) : base(sender) { }

        [HttpGet("GetProductCategoryId")]
        public async Task<IActionResult> Get([FromQuery] int id, CancellationToken ct)
        {
            var productCategory = await Sender.Send(new GetProductCategoryByIdQuery(id), ct);
            return Ok(productCategory);
        }

        [HttpGet("GetProductCategoryList")]
        public async Task<IActionResult> Get( CancellationToken ct)
        {
            var productCategoryList = await Sender.Send(new GetProductCategoryListQuery(), ct);
            return Ok(productCategoryList);
        }

        [HttpPut("UpdateProductCategory")]
        public async Task<IActionResult> Update([FromBody] UpdateProductCategoryCommand request, CancellationToken ct)
        {
            var result = await Sender.Send(request, ct);
            return Ok(result);
        }

        [HttpPost("CreateProductCategory")]
        public async Task<IActionResult> Create([FromBody] DeleteProductCategoryCommand request, CancellationToken ct)
        {
            var productCategory = await Sender.Send(request, ct);
            return Ok(productCategory);

        }

        [HttpDelete("DeleteProductCategory")]
        public async Task<IActionResult> Delete(DeleteProductCategoryCommand request, CancellationToken ct)
        {   
            var deletedItem = await Sender.Send(request, ct);
            return Ok(deletedItem);
        }

    }
}
