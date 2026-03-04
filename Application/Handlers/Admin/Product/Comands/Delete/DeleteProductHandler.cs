using Application.Common.Caching;
using Application.Interfaces.Auth;
using Application.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Admin.Product.Comands.Delete
{
    public sealed class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly ISabaShopDb _db;
        private readonly ICacheService _cache;

        public DeleteProductHandler(ISabaShopDb db, ICacheService cache)
        {
            _db = db;
            _cache = cache;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken ct)
        {
            var product = await _db.Products
                .FirstOrDefaultAsync(p => p.Id == request.Id && p.DeleteTime == null, ct);

            if (product is null)
                throw new KeyNotFoundException($"Product with Id={request.Id} not found.");

            var categoryId = product.Product_CategoryId;

            product.DeleteTime = DateTime.UtcNow;
            await _db.SaveChangesAsync(ct);

            _cache.Remove(CacheKeys.ProductList);
            _cache.Remove(CacheKeys.ProductById(request.Id));
            _cache.Remove(CacheKeys.ProductCategoryList);
            _cache.Remove(CacheKeys.ProductCategoryById(categoryId));

            return Unit.Value;
        }
    }
}
