using Application.DTO.Auth;
using Application.Handlers.Admin.MeAutorization;
using Application.Handlers.Public.Auth.Commands.CHangePassword;
using Application.Handlers.Public.Auth.Commands.Login;
using Application.Handlers.Public.Auth.Commands.Refresh;
using Application.Handlers.Public.Auth.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sabas_Shop.Settings;

namespace Sabas_Shop.Controllers.Auth
{
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthController : ApiControllerBase
    {
        public AuthController(ISender sender) : base(sender) { }

        [HttpPost("register")]
        public Task<AuthResponseDto> Register([FromBody] RegisterCommand cmd, CancellationToken ct) =>
            Sender.Send(cmd, ct);

        [HttpPost("login")]
        public Task<LoginResponseDto> Login([FromBody] LoginCommand cmd, CancellationToken ct) =>
            Sender.Send(cmd, ct);

        [HttpPost("refresh")]
        public Task<AuthResponseDto> Refresh([FromBody] RefreshCommand cmd, CancellationToken ct) =>
            Sender.Send(cmd, ct);

        [HttpPut("changePassword")]
        public Task<string> ChangePasssword([FromBody] ChangePasswordCommand cmd, CancellationToken ct) =>
            Sender.Send(cmd, ct);

        [Authorize]
        [HttpGet("LoginCheck")]
        public Task<UserDTO> LoginCheck( CancellationToken ct) =>
            Sender.Send(new LogginCheckQuery(), ct);

    }
}
 