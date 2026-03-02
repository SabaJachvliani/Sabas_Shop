using MediatR;

namespace Application.Handlers.Admin.ProductCategory.Command.Update
{
    public record UpdateProductCategoryCommand
    (
        int Id,
        string Name 
    )
        : IRequest<int>;

}
