using Application.DTO.Product;
using MediatR;

namespace Application.Handlers.Admin.Product.Queries.GetProductList
{
    public record GetProductListQuery() : IRequest<List<GetProductListDTO>>;
    
    
}
