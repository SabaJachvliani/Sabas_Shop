using Application.DTO.ProductCategory;
using Application.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Admin.ProductCategory.Queries.GetProductCategoruById
{
    public class GetProductCategoruByIdHandler : IRequestHandler<GetProductCategoryByIdQuery, GetProductCategoryByIdDTO>
    {
        public readonly ISabaShopDb _db;
        public GetProductCategoruByIdHandler(ISabaShopDb db) => _db = db;
        public async Task<GetProductCategoryByIdDTO> Handle(GetProductCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var ProductCategory = await _db.Categories.Where(x => x.Id == request.Id)
                .Select(x => new GetProductCategoryByIdDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .FirstOrDefaultAsync(cancellationToken);
            

            if (ProductCategory == null)
            {
                throw new Exception("error");
            }
            return ProductCategory;
        }
    }
}
