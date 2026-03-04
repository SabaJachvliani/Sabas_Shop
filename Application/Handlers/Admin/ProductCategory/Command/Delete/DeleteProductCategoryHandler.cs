using Application.Common.Caching;
using Application.Interfaces.Auth;
using Application.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Admin.ProductCategory.Command.Delete
{
    public class DeleteProductCategoryHandler : IRequestHandler<DeleteProductCategoryCommand, Unit>
    {
        private readonly ISabaShopDb _db;
        private readonly ICacheService _cache;

        public DeleteProductCategoryHandler(ISabaShopDb db, ICacheService cache)
        {
            _db = db;
            _cache = cache;
        }

        public async Task<Unit> Handle(DeleteProductCategoryCommand request, CancellationToken ct)
        {
            
            var hasProducts = await _db.Products
                .AsNoTracking()
                .AnyAsync(p => p.Product_CategoryId == request.Id && p.DeleteTime == null, ct);

            if (hasProducts)
                throw new InvalidOperationException("You cannot delete this category because it has products.");

            var category = await _db.Categories
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.deleteDate == null, ct); 

            if (category is null)
                throw new KeyNotFoundException($"Category with id {request.Id} not found");

            category.deleteDate = DateTime.UtcNow; 
            await _db.SaveChangesAsync(ct);

            _cache.Remove(CacheKeys.ProductCategoryList);
            _cache.Remove(CacheKeys.ProductCategoryById(request.Id));
            _cache.Remove(CacheKeys.ProductList);

            return Unit.Value;
        }
    }
}
