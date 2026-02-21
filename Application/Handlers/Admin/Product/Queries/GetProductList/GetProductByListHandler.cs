using Application.DTO.Product;
using Application.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Admin.Product.Queries.GetProductList
{
    public class GetProductByListHandler : IRequestHandler<GetProductListQuery, List<GetProductListDTO>>
    {
        public readonly ISabaShopDb _db;
        public GetProductByListHandler(ISabaShopDb db) => _db = db;
        public async Task<List<GetProductListDTO>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            return await _db.Products.Where(x => x.DeleteTime == null)
            .Select(p => new GetProductListDTO
            {

                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description
                
            })
            .ToListAsync(cancellationToken);

        }
    }
}
