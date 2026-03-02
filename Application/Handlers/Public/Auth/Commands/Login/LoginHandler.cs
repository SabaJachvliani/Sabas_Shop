using Application.Interfaces.Auth;
using Domain.Entities.RefreshToken;
using MediatR;

namespace Application.Handlers.Public.Auth.Commands.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResponseDto>
    {
        private readonly IUserRepository _users;
        private readonly IPasswordService _passwords;
        private readonly IJwtTokenService _jwt;
        private readonly IRefreshTokenRepository _refreshTokens;

        public LoginHandler(IUserRepository users, IPasswordService passwords, IJwtTokenService jwt, IRefreshTokenRepository refreshTokens)
        {
            _users = users;
            _passwords = passwords;
            _jwt = jwt;
            _refreshTokens = refreshTokens;
        }

        public async Task<LoginResponseDto> Handle(LoginCommand request, CancellationToken ct)
        {
            var email = request.Email.Trim().ToLower();
            var user = await _users.GetByEmailAsync(email, ct);

            if (user == null) throw new Exception("Invalid credentials");

            var ok = _passwords.Verify(request.Password, user.PasswordHash);
            if (!ok) throw new Exception("Invalid credentials");

            var token = _jwt.CreateAccessToken(user);
            var refresh = _jwt.CreateRefreshToken();
            var newHash = _jwt.HashToken(refresh);

            await _refreshTokens.AddAsync(new ShopRefreshToken
            {
                UserId = user.Id,
                TokenHash = newHash,
                CreatedAtUtc = DateTime.UtcNow,
                ExpiresAtUtc = _jwt.GetRefreshTokenExpiryUtc()
            }, ct);

            await _refreshTokens.SaveChangesAsync(ct);

            return new LoginResponseDto(token, refresh);
        }
    }
} 
