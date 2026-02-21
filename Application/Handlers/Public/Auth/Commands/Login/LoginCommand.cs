using MediatR;

namespace Application.Handlers.Public.Auth.Commands.Login
{
    public record LoginCommand(string Email, string Password) : IRequest<LoginResponseDto>;
    public record LoginResponseDto(string AccessToken);
}
