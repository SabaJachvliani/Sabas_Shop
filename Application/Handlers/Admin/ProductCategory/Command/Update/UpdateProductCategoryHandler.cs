using Application.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Admin.ProductCategory.Command.Update
{
    public class UpdateProductCategoryHandler : IRequestHandler<UpdateProductCategoryCommand, int>
    {
        public readonly ISabaShopDb _db;
        public UpdateProductCategoryHandler(ISabaShopDb db) => _db = db;
        public async Task<int> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (category is null)
            {
                throw new Exception($"Product with id {request.Id} not found");
            }

            category.Name = request.Name;
            

            await _db.SaveChangesAsync(cancellationToken);

            return category.Id;
        }
    }
}
