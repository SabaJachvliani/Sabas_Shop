using Application.DTO.Auth;
using MediatR;

namespace Application.Handlers.Public.Auth.Commands.Refresh
{
    public record RefreshCommand(string RefreshToken) : IRequest<AuthResponseDto>;
}
