using Application.DTO.Auth;
using Application.Interfaces.Auth;
using Domain.Entities;
using Domain.Entities.RefreshToken;
using MediatR;

namespace Application.Handlers.Public.Auth.Commands.Register
{
    internal class RegisterHandler : IRequestHandler<RegisterCommand, AuthResponseDto>
    {
        private readonly IUserRepository _users;
        private readonly IPasswordService _passwords;
        private readonly IJwtTokenService _jwt;
        private readonly IRefreshTokenRepository _refreshTokens;

        public RegisterHandler(IUserRepository users, IPasswordService passwords, IJwtTokenService jwt, IRefreshTokenRepository refreshTokens)
        {
            _users = users;
            _passwords = passwords;
            _jwt = jwt;
            _refreshTokens = refreshTokens;
        }
        public async Task<AuthResponseDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {

            var email = request.Email.Trim().ToLower();

            var exists = await _users.GetByEmailAsync(email, cancellationToken);
            if (exists != null) throw new Exception("User already exists"); 



            var user = new ShopCostumer
            {

                FirstName = request.FirstName,
                LastName = request.LastName,
                Mail = email,
                PasswordHash = _passwords.Hash(request.Password),
                Role = "User"
            };

            await _users.AddAsync(user, cancellationToken);
            await _users.SaveChangesAsync(cancellationToken);

            
            var access = _jwt.CreateAccessToken(user);

            var refresh = _jwt.CreateRefreshToken();
            var refreshHash = _jwt.HashToken(refresh);

            await _refreshTokens.AddAsync(new ShopRefreshToken
            {
                UserId = user.Id,
                TokenHash = refreshHash,
                CreatedAtUtc = DateTime.UtcNow,
                ExpiresAtUtc = _jwt.GetRefreshTokenExpiryUtc()
            }, cancellationToken);

            await _refreshTokens.SaveChangesAsync(cancellationToken);

            return new AuthResponseDto(access, refresh);

            

        }
    }
}
