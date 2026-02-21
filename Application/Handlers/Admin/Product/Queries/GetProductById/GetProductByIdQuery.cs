using Application.DTO.Product;
using MediatR;

namespace Application.Handlers.Admin.Product.Queries.GetProductById
{
    public record GetProductByIdQuery(int Id) : IRequest<GetProductByIdDTO>;
    
}
