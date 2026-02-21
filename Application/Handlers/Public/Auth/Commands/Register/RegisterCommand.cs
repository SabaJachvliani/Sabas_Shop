using Application.DTO.Auth;
using MediatR;

namespace Application.Handlers.Public.Auth.Commands.Register
{
    public record RegisterCommand
    (
        string FirstName, 
        string LastName, 
        string Email, 
        string Password
    ) : IRequest<AuthResponseDto>;

    

}
