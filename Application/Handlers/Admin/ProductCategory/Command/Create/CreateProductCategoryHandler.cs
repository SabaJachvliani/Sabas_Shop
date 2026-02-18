using Application.Interfaces.Infrastructure;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Admin.ProductCategory.Command.Create
{
    internal class CreateProductCategoryHandler : IRequestHandler<CreateProductCategoryCommand, int>
    {
        public readonly ISabaShopDb _db;
        public CreateProductCategoryHandler(ISabaShopDb db) => _db = db;    
        public async Task<int> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new ShopProductCategory
            {
                Name = request.Name
            };


            _db.Categories.Add(category);
            await _db.SaveChangesAsync(cancellationToken);
            return  category.Id;
             
        }
    }
}
