using Application.DTO.Auth;
using Application.Handlers.Public.Auth.Commands.Login;
using Application.Handlers.Public.Auth.Commands.Refresh;
using Application.Handlers.Public.Auth.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sabas_Shop.Settings;

namespace Sabas_Shop.Controllers.Auth
{
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthController : ApiControllerBase
    {
        
        public AuthController(ISender sender) : base(sender) { }

        [HttpPost("register")]
        public Task<AuthResponseDto> Register(RegisterCommand cmd) =>
            Sender.Send(cmd);

        [HttpPost("login")]
        public Task<LoginResponseDto> Login(LoginCommand cmd) =>
            Sender.Send(cmd);

        [HttpPost("refresh")]
        public Task<AuthResponseDto> Refresh([FromBody] RefreshCommand cmd) =>
            Sender.Send(cmd);
    }
}
 