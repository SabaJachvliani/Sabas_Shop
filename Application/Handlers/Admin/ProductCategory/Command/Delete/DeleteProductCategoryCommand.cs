using MediatR;

namespace Application.Handlers.Admin.ProductCategory.Command.Delete
{
    public record DeleteProductCategoryCommand
    (
        int Id
    )
        : IRequest<Unit>;
}
