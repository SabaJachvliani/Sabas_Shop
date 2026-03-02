using Application.Common.Caching;
using Application.Interfaces.Auth;
using Application.Interfaces.Infrastructure;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Admin.ProductCategory.Command.Create
{
    internal class CreateProductCategoryHandler : IRequestHandler<CreateProductCategoryCommand, int>
    {
        private readonly ISabaShopDb _db;
        private readonly ICacheService _cache;

        public CreateProductCategoryHandler(ISabaShopDb db, ICacheService cache)
        {
            _db = db;
            _cache = cache;
        }
        public async Task<int> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new ShopProductCategory
            {
                Name = request.Name
            };


            _db.Categories.Add(category);
            await _db.SaveChangesAsync(cancellationToken);

            _cache.Remove(CacheKeys.ProductCategoryList);
            _cache.Remove(CacheKeys.ProductCategoryById(category.Id));

            return category.Id;
             
        }
    }
}
