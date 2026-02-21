using Domain.Entities.RefreshToken;

namespace Application.Interfaces.Auth
{
    public interface IRefreshTokenRepository
    {
        Task<ShopRefreshToken?> GetByHashAsync(string tokenHash, CancellationToken ct);
        Task AddAsync(ShopRefreshToken token, CancellationToken ct);
        Task SaveChangesAsync(CancellationToken ct);
    }
}
