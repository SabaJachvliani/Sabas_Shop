using Application.Common.Caching;
using Application.DTO.ProductCategory;
using Application.Interfaces.Auth;
using Application.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Admin.ProductCategory.Queries.GetProductCategoruById
{
    public class GetProductCategoryByIdHandler : IRequestHandler<GetProductCategoryByIdQuery, GetProductCategoryDTO>
    {
        private readonly ISabaShopDb _db;
        private readonly ICacheService _cache;

        public GetProductCategoryByIdHandler(ISabaShopDb db, ICacheService cache)
        {
            _db = db;
            _cache = cache;
        }
        public async Task<GetProductCategoryDTO> Handle(GetProductCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var key = CacheKeys.ProductCategoryById(request.Id);

            return await _cache.GetOrCreateAsync(
                key,
                TimeSpan.FromMinutes(30),
                async token =>
                {
                    var ProductCategory = await _db.Categories.Where(x => x.Id == request.Id)
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

                   }).ToList()

                }).FirstOrDefaultAsync(token);

                    if (ProductCategory is null)
                    {
                        throw new KeyNotFoundException($"Category with id {request.Id} not found.");
                    }
                    return ProductCategory;

                }, cancellationToken);

        }
    }
}
