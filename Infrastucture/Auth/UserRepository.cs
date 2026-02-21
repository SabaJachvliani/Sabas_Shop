using Application.Interfaces.Auth;
using Domain.Entities;
using Infrastucture.SabaShopDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Auth
{
    public class UserRepository : IUserRepository
    {
        private readonly SabaShopDb _db; 

        public UserRepository(SabaShopDb db) => _db = db;
        public Task AddAsync(ShopCostumer user, CancellationToken ct)
        {
            return _db.Costumers.AddAsync(user, ct).AsTask();
        }

        public Task<ShopCostumer?> GetByEmailAsync(string email, CancellationToken ct)
        {
           return _db.Costumers.FirstOrDefaultAsync(x => x.Mail == email, ct);
        }

        public Task<ShopCostumer?> GetByIdAsync(int id, CancellationToken ct)
        {
            return _db.Costumers.FirstOrDefaultAsync(x =>x.Id == id, ct);
        }

        public Task SaveChangesAsync(CancellationToken ct)
        {
            return _db.SaveChangesAsync(ct);
        }
    }
}
