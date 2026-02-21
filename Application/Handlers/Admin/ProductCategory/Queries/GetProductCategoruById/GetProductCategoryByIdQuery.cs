using Application.DTO.ProductCategory;
using MediatR;

namespace Application.Handlers.Admin.ProductCategory.Queries.GetProductCategoruById
{
    public record GetProductCategoryByIdQuery(int Id) : IRequest<GetProductCategoryByIdDTO>;
    
}
