using Application.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers.Admin.Product.Comands.Update
{
    internal class UpdateProductHandler : IRequestHandler<UpdateProductCommand, int>
    {
        public readonly ISabaShopDb _db;
        public UpdateProductHandler(ISabaShopDb db) => _db = db;
        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (product is null)
                throw new Exception($"Product with id {request.Id} not found"); 

            product.Name = request.Name;
            product.Price = request.Price;
            product.Description = request.Description;
            product.Product_CategoryId = request.ProductCategoryId;

            await _db.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
