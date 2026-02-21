using Application.Interfaces.Auth;
using MediatR;

namespace Application.Handlers.Public.Auth.Commands.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResponseDto>
    {
        private readonly IUserRepository _users;
        private readonly IPasswordService _passwords;
        private readonly IJwtTokenService _jwt;

        public LoginHandler(IUserRepository users, IPasswordService passwords, IJwtTokenService jwt)
        {
            _users = users;
            _passwords = passwords;
            _jwt = jwt;
        }

        public async Task<LoginResponseDto> Handle(LoginCommand request, CancellationToken ct)
        {
            var email = request.Email.Trim().ToLower();
            var user = await _users.GetByEmailAsync(email, ct);

            if (user == null) throw new Exception("Invalid credentials");

            var ok = _passwords.Verify(request.Password, user.PasswordHash);
            if (!ok) throw new Exception("Invalid credentials");

            var token = _jwt.CreateAccessToken(user);
            return new LoginResponseDto(token);
        }
    }
}
