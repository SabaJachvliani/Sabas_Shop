using Application.Common.Caching;
using Application.Interfaces.Auth;
using Application.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Admin.ProductCategory.Command.Update
{
    public class UpdateProductCategoryHandler : IRequestHandler<UpdateProductCategoryCommand, int>
    {
        private readonly ISabaShopDb _db;
        private readonly ICacheService _cache;

        public UpdateProductCategoryHandler(ISabaShopDb db, ICacheService cache)
        {
            _db = db;
            _cache = cache;
        }
        public async Task<int> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (category is null)
            {
                throw new KeyNotFoundException($"Category with id {request.Id} not found");
            }

            category.Name = request.Name;

            await _db.SaveChangesAsync(cancellationToken);

            _cache.Remove(CacheKeys.ProductCategoryList);
            _cache.Remove(CacheKeys.ProductCategoryById(request.Id));

            return category.Id;
        }
    }
}
