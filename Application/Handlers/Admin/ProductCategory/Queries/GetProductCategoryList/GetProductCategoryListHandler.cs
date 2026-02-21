using Application.DTO.ProductCategory;
using Application.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Admin.ProductCategory.Queries.GetProductCategoryList
{
    public class GetProductCategoryListHandler : IRequestHandler<GetProductCategoryListQuery, List<GetProductCategoryListDTO>>
    {
        public readonly ISabaShopDb _db;
        public GetProductCategoryListHandler(ISabaShopDb db) => _db = db;
        public async Task<List<GetProductCategoryListDTO>> Handle(GetProductCategoryListQuery request, CancellationToken cancellationToken)
        {
            return await _db.Categories
                .Select(x => new GetProductCategoryListDTO
            {
                    Id = x.Id,
                    Name = x.Name,

            }).ToListAsync();

        }
    }
}
