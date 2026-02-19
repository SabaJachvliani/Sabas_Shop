using Application.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Admin.Product.Comands.Delete
{
    public sealed class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly ISabaShopDb _db;

        public DeleteProductHandler(ISabaShopDb db) => _db = db;

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken ct)
        {
            var affected = await _db.Products
                .FirstOrDefaultAsync(p => p.Id == request.Id);
                

            if (affected is null)
                throw new KeyNotFoundException($"Product with Id={request.Id} not found.");

            affected.DeleteTime = DateTime.UtcNow;



            return Unit.Value;
        }
    }
}
