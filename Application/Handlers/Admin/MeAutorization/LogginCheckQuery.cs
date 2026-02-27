using Application.DTO.Auth;
using MediatR;

namespace Application.Handlers.Admin.MeAutorization
{
    public class LogginCheckQuery : IRequest<UserDTO>;
   
}
