using Application.Common.Caching;
using Application.Interfaces.Auth;
using Application.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Admin.Product.Comands.Update
{
    internal class UpdateProductHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly ISabaShopDb _db;
        private readonly ICacheService _cache;

        public UpdateProductHandler(ISabaShopDb db, ICacheService cache)
        {
            _db = db;
            _cache = cache;
        }
        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (product is null)
                throw new Exception($"Product with id {request.Id} not found");

            var oldCategoryId = product.Product_CategoryId;

            product.Name = request.Name;
            product.Price = request.Price;
            product.Description = request.Description;
            product.Product_CategoryId = request.ProductCategoryId;

            await _db.SaveChangesAsync(cancellationToken);

            _cache.Remove(CacheKeys.ProductList);
            _cache.Remove(CacheKeys.ProductById(product.Id));
            _cache.Remove(CacheKeys.ProductCategoryList);
            _cache.Remove(CacheKeys.ProductCategoryById(oldCategoryId));
            _cache.Remove(CacheKeys.ProductCategoryById(product.Product_CategoryId));

            return product.Id;
        }
    }
}
