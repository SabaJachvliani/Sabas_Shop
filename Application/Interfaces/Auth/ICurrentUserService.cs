namespace Application.Interfaces.Auth
{
    public interface ICurrentUserService
    {
        bool IsAuthenticated { get; }
        int? UserId { get; }
        string? Email { get; }
        IReadOnlyList<string> Roles { get; }
    }
}
