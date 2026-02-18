using Application.Handlers.Admin.Product.Comands.Delete;
using Application.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers.Admin.ProductCategory.Command.Delete
{
    public class DeleteProductCategoryHandler : IRequestHandler<DeleteProductCategoryCommand, Unit>
    {
        private readonly ISabaShopDb _db;
        public DeleteProductCategoryHandler(ISabaShopDb db) => _db = db;
        public async Task<Unit> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _db.Categories.Where(x => x.Id == request.Id).ExecuteDeleteAsync(cancellationToken);

            if (result == 0)
            {
                throw new KeyNotFoundException($"Product with Id={request.Id} not found.");
            }

            return Unit.Value;
        }
    }
}
