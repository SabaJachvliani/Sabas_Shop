using Application.DTO.Auth;
using Application.Interfaces.Auth;
using Domain.Entities.RefreshToken;
using MediatR;

namespace Application.Handlers.Public.Auth.Commands.Refresh
{
    public class RefreshHandler : IRequestHandler<RefreshCommand, AuthResponseDto>
    {
        private readonly IUserRepository _users;
        private readonly IRefreshTokenRepository _tokens;
        private readonly IJwtTokenService _jwt;

        public RefreshHandler(IUserRepository users, IRefreshTokenRepository tokens, IJwtTokenService jwt)
        {
            _users = users;
            _tokens = tokens;
            _jwt = jwt;
        }

        public async Task<AuthResponseDto> Handle(RefreshCommand request, CancellationToken ct)
        {
            var oldHash = _jwt.HashToken(request.RefreshToken);
            var oldToken = await _tokens.GetByHashAsync(oldHash, ct);

            if (oldToken == null || !oldToken.IsActive)
                throw new Exception("Invalid refresh token");

           
            var user = await _users.GetByIdAsync(oldToken.UserId, ct);
            if (user == null) throw new Exception("User not found");

            var newAccess = _jwt.CreateAccessToken(user);
            var newRefresh = _jwt.CreateRefreshToken();
            var newHash = _jwt.HashToken(newRefresh);

            oldToken.RevokedAtUtc = DateTime.UtcNow;
            oldToken.ReplacedByTokenHash = newHash;

            await _tokens.AddAsync(new ShopRefreshToken
            {
                UserId = user.Id,
                TokenHash = newHash,
                CreatedAtUtc = DateTime.UtcNow,
                ExpiresAtUtc = _jwt.GetRefreshTokenExpiryUtc()
            }, ct);

            await _tokens.SaveChangesAsync(ct);
            
            return new AuthResponseDto(newAccess, newRefresh);
        }
    }
}
