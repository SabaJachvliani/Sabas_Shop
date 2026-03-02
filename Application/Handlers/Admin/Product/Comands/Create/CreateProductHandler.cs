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
        private readonly IFileStorage _files;

        public CreateProductHandler(ISabaShopDb db, ICacheService cache, IFileStorage files)
        {
            _db = db;
            _cache = cache;
            _files = files;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new ShopProduct
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description ?? "",
                Product_CategoryId = request.ProductCategoryId
            };

            _db.Products.Add(product);
            await _db.SaveChangesAsync(cancellationToken); 

            if (request.Photos is not null && request.Photos.Count > 0)
            {
                for (int i = 0; i < request.Photos.Count; i++)
                {
                    var photo = request.Photos[i];

                    var url = await _files.SaveProductPhotoAsync(
                        photo.Content,
                        photo.FileName,
                        photo.ContentType,
                        cancellationToken
                    );

                    product.Photos.Add(new ShopProductPhoto
                    {
                        ProductId = product.Id,
                        Url = url,
                        Order = i
                    });
                  
                    if (i == 0)
                        product.PhotoUrl = url;
                }

                await _db.SaveChangesAsync(cancellationToken);
            }

            _cache.Remove(CacheKeys.ProductList);
            _cache.Remove(CacheKeys.ProductCategoryList);
            _cache.Remove(CacheKeys.ProductCategoryById(request.ProductCategoryId));
            _cache.Remove(CacheKeys.ProductById(product.Id));

            return product.Id;
        }
    }
}
