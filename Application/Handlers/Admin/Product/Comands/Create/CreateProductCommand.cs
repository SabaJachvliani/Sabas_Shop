using MediatR;

namespace Application.Handlers.Admin.Product.Comands.Create
{
    public record CreateProductCommand
    (
     string Name,
     decimal Price,
     string? Description,
     int ProductCategoryId,
     List<PhotoUpload>? Photos = null
    )
        : IRequest<int>;
}
