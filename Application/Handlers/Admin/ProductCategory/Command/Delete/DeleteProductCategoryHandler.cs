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
        public async Task<Unit> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _db.Categories.Where(x => x.Id == request.Id).ExecuteDeleteAsync(cancellationToken);

            if (result == 0)
            {
                throw new KeyNotFoundException($"Category with Id={request.Id} not found.");
            }

            _cache.Remove(CacheKeys.ProductCategoryList);
            _cache.Remove(CacheKeys.ProductCategoryById(request.Id));
            _cache.Remove(CacheKeys.ProductList);

            return Unit.Value;
        }
    }
}
