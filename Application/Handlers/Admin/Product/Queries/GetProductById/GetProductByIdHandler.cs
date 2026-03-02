using Application.Common.Caching;
using Application.DTO.Product;
using Application.Interfaces.Auth;
using Application.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Admin.Product.Queries.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, GetProductDTO>
    {
        private readonly ISabaShopDb _db;
        private readonly ICacheService _cache;

        public GetProductByIdHandler(ISabaShopDb db, ICacheService cache)
        {
            _db = db;
            _cache = cache;
        }
        public async Task<GetProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var key = CacheKeys.ProductById(request.Id);

            return await _cache.GetOrCreateAsync(
                key,
                TimeSpan.FromMinutes(10),
                async token =>
                {
                      var product = await _db.Products.Where(x => x.DeleteTime == null && x.Id == request.Id)
                    .Select(x => new GetProductDTO
                    {
                           Id = x.Id,
                           Name = x.Name,
                           Price = x.Price,
                           Description = x.Description,

                        Category = new ProductCategoryDTO
                        {
                            Id = x.ShopProductCategorys.Id,
                            Name = x.ShopProductCategorys.Name,
                        }
                    })
                    .FirstOrDefaultAsync(cancellationToken);

                    if (product is null)
                        throw new KeyNotFoundException($"Product with id {request.Id} not found.");

                    return product;

                }, cancellationToken);

        }
    }
}
