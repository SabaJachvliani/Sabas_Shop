using MediatR;

namespace Application.Handlers.Admin.Product.Comands.Delete
{
    public record DeleteProductCommand(int Id) : IRequest<Unit>;
        
}
