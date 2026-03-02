using Application.Common.Caching;
using Application.DTO.ProductCategory;
using Application.Interfaces.Auth;
using Application.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Admin.ProductCategory.Queries.GetProductCategoryList
{
    public class GetProductCategoryListHandler : IRequestHandler<GetProductCategoryListQuery, List<GetProductCategoryDTO>>
    {
        private readonly ISabaShopDb _db;
        private readonly ICacheService _cache;

        public GetProductCategoryListHandler(ISabaShopDb db, ICacheService cache)
        {
            _db = db;
            _cache = cache;
        }
        public async Task<List<GetProductCategoryDTO>> Handle(GetProductCategoryListQuery request, CancellationToken cancellationToken)
        {
            return await _cache.GetOrCreateAsync(
            CacheKeys.ProductCategoryList,
            TimeSpan.FromMinutes(30),
            async token =>
            {
                return await _db.Categories
                    .Select(x => new GetProductCategoryDTO
                    {
                        Id = x.Id,
                        Name = x.Name,

                        Products = x.ShopProducts
                       .Where(p => p.DeleteTime == null)
                       .Select(p => new ProductsInCategoryDTO
                       {
                           Id = p.Id,
                           Name = p.Name,
                           Price = p.Price
                       })
                    .ToList()

                    }).ToListAsync(token);

            }, cancellationToken);

        }
    }
}
