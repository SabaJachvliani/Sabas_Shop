using Application.Interfaces.Auth;
using System.Security.Claims;

namespace Sabas_Shop.Services
{
    public sealed class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _http;

        public CurrentUserService(IHttpContextAccessor http)
            => _http = http;

        private ClaimsPrincipal? User => _http.HttpContext?.User;

        public bool IsAuthenticated => User?.Identity?.IsAuthenticated == true;

        public int? UserId
        {
            get
            {
                var raw =
                    User?.FindFirstValue(ClaimTypes.NameIdentifier) ??
                    User?.FindFirstValue("sub");

                if (string.IsNullOrWhiteSpace(raw))
                    return null;

                return int.TryParse(raw, out var id) ? id : null;
            }
        }

        public string? Email => User?.FindFirstValue(ClaimTypes.Email) ?? User?.FindFirstValue("email");

        public IReadOnlyList<string> Roles =>
            User?.FindAll(ClaimTypes.Role).Select(x => x.Value).ToList()
            ?? new List<string>();
       
    }
}
