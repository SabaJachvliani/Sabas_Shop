using Application.Handlers.Admin.Product.Comands;
using Application.Handlers.Admin.Product.Comands.Create;
using Application.Handlers.Admin.Product.Comands.Delete;
using Application.Handlers.Admin.Product.Comands.Update;
using Application.Handlers.Admin.Product.Queries.GetProductById;
using Application.Handlers.Admin.Product.Queries.GetProductList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sabas_Shop.Requests;
using Sabas_Shop.Settings;

namespace Sabas_Shop.Controllers.Admin.Product
{

    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductController : ApiControllerBase
    {
        public ProductController(ISender sender) : base(sender) { }

        [HttpPost("Create")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] CreateProductRequest request, CancellationToken ct)
        {
            const int MaxPhotos = 5;
            const long MaxPhotoBytes = 2 * 1024 * 1024;

            string[] allowedContentTypes = { "image/jpeg", "image/png", "image/webp" };
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };

            var photos = request.Photos ?? new List<IFormFile>();

            if (photos.Count > MaxPhotos)
                return BadRequest($"Too many photos. Max is {MaxPhotos}.");

            var uploads = new List<PhotoUpload>();

            foreach (var photo in photos)
            {
                if (photo.Length <= 0)
                    return BadRequest("One of the photos is empty.");

                if (photo.Length > MaxPhotoBytes)
                    return BadRequest("One of the photos is too large. Max size is 2MB each.");

                var ext = Path.GetExtension(photo.FileName);
                if (string.IsNullOrWhiteSpace(ext) || !allowedExtensions.Contains(ext, StringComparer.OrdinalIgnoreCase))
                    return BadRequest("Invalid photo extension. Allowed: jpg, jpeg, png, webp.");

                if (!allowedContentTypes.Contains(photo.ContentType, StringComparer.OrdinalIgnoreCase))
                    return BadRequest("Invalid file type. Only images are allowed (jpeg/png/webp).");

                using var ms = new MemoryStream();
                await photo.CopyToAsync(ms, ct);

                uploads.Add(new PhotoUpload(ms.ToArray(), photo.FileName, photo.ContentType));
            }

            var id = await Sender.Send(
                new CreateProductCommand(
                    request.Name,
                    request.Price,
                    request.Description,
                    request.ProductCategoryId,
                    uploads.Count == 0 ? null : uploads
                ),
                ct
            );

            return Ok(id);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] UpdateProductCommand command, CancellationToken ct)
        {

            var updatedId = Sender.Send(command, ct);
            return (IActionResult)updatedId;
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int id, CancellationToken ct)
        {
            await Sender.Send(new DeleteProductCommand(id), ct);
            return NoContent();
        }

        [HttpGet("GetProductList")]
        public async Task<IActionResult> Get(CancellationToken ct)
        {
            var productList = await Sender.Send(new GetProductListQuery(), ct);
            return Ok(productList);
        }

        [HttpGet("GetProductById")]
        public async Task<IActionResult> Get([FromQuery] int id, CancellationToken ct)
        {
            var productById = await Sender.Send(new GetProductByIdQuery(id), ct);
            return Ok(productById);
        }

    }
}
