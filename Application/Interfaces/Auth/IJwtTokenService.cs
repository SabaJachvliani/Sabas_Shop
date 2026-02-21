using Domain.Entities;

namespace Application.Interfaces.Auth
{
    public interface IJwtTokenService
    {
        string CreateAccessToken(ShopCostumer user);
        string CreateRefreshToken();
        string HashToken(string token);
        DateTime GetRefreshTokenExpiryUtc();
    }
}
