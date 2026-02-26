using MediatR;

namespace Application.Handlers.Public.Auth.Commands.CHangePassword
{
    public record ChangePasswordCommand 
    (
         
         string Mail,
         string Password,
         string NewPassword

    )
         : IRequest<string>;

}
