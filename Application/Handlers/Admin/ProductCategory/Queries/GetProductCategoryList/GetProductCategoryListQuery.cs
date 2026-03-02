using Application.DTO.ProductCategory;
using MediatR;

namespace Application.Handlers.Admin.ProductCategory.Queries.GetProductCategoryList
{
    public record GetProductCategoryListQuery() : IRequest<List<GetProductCategoryDTO>>;
    
}
