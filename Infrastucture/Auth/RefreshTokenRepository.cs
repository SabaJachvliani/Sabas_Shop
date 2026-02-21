using Application.Interfaces.Auth;
using Domain.Entities.RefreshToken;
using Infrastucture.SabaShopDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Auth
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly SabaShopDb _db;
        public RefreshTokenRepository(SabaShopDb db) => _db = db;

        public Task<ShopRefreshToken?> GetByHashAsync(string tokenHash, CancellationToken ct) =>
            _db.RefreshTokens.FirstOrDefaultAsync(x => x.TokenHash == tokenHash, ct);

        public Task AddAsync(ShopRefreshToken token, CancellationToken ct) =>
            _db.RefreshTokens.AddAsync(token, ct).AsTask();

        public Task SaveChangesAsync(CancellationToken ct) =>
            _db.SaveChangesAsync(ct);
    }
}
