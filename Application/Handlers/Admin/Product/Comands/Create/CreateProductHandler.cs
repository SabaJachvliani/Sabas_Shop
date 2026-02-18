using Application.Interfaces.Infrastructure;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers.Admin.Product.Comands.Create
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
    {
        public readonly ISabaShopDb _db;
        public CreateProductHandler(ISabaShopDb db) => _db=db;
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
            return product.Id;
        }
    }
}
