using MediatR;

namespace Application.Handlers.Admin.Product.Comands.Update
{
    public record UpdateProductCommand(
        int Id,
        string Name,
        decimal Price,
        string Description,
        int ProductCategoryId
    ) : IRequest<int>;
}
