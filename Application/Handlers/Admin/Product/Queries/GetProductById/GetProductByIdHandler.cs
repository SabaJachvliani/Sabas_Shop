using Application.DTO.Product;
using Application.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Admin.Product.Queries.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdDTO>
    {
        public readonly ISabaShopDb _db;
        public GetProductByIdHandler(ISabaShopDb db) => _db = db;
        public async Task<GetProductByIdDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _db.Products.Where(x => x.DeleteTime == null && x.Id == request.Id)
                .Select(x => new GetProductByIdDTO
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Description = x.Description                

            })
                .FirstOrDefaultAsync(cancellationToken);
            if(product is null)
                throw new KeyNotFoundException($"Product with id {request.Id} not found.");

            return product;
        }
    }
}
