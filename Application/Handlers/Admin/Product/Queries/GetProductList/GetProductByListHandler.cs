using Application.Common.Caching;
using Application.DTO.Product;
using Application.Interfaces.Auth;
using Application.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Admin.Product.Queries.GetProductList
{
    public class GetProductByListHandler : IRequestHandler<GetProductListQuery, List<GetProductDTO>>
    {
        private readonly ISabaShopDb _db;
        private readonly ICacheService _cache;

        public GetProductByListHandler(ISabaShopDb db, ICacheService cache)
        {
            _db = db;
            _cache = cache;
        }
        public async Task<List<GetProductDTO>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            return await _cache.GetOrCreateAsync(
        CacheKeys.ProductList,
        TimeSpan.FromMinutes(10),
        async token =>
        {
            return await _db.Products
                .AsNoTracking()
                .Where(x => x.DeleteTime == null)
                .Select(p => new GetProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    Category = new ProductCategoryDTO
                    {
                        Id = p.ShopProductCategorys.Id,
                        Name = p.ShopProductCategorys.Name
                    }
                })
                .ToListAsync(token);
        },
        cancellationToken);

        }
    }
}
