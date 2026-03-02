using MediatR;

namespace Application.Handlers.Admin.ProductCategory.Command.Create
{
    public record CreateProductCategoryCommand
    (
        string Name
    )
        : IRequest<int>;
    
}
