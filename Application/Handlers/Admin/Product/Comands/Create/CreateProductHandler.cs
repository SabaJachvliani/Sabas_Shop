using Application.Common.Caching;
using Application.Interfaces.Auth;
using Application.Interfaces.Infrastructure;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Admin.Product.Comands.Create
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly ISabaShopDb _db;
        private readonly ICacheService _cache;

        public CreateProductHandler(ISabaShopDb db, ICacheService cache)
        {
            _db = db;
            _cache = cache;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new ShopProduct
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                Product_CategoryId = request.ProductCategoryId

            };

            _db.Products.Add(product);
            await _db.SaveChangesAsync(cancellationToken);

            _cache.Remove(CacheKeys.ProductList);
            _cache.Remove(CacheKeys.ProductCategoryList);
            _cache.Remove(CacheKeys.ProductCategoryById(request.ProductCategoryId));            
            _cache.Remove(CacheKeys.ProductById(product.Id));

            return product.Id;
        }
    }
}
