using Domain.Entities;

namespace Application.Interfaces.Auth
{
    public interface IUserRepository
    {
        Task<ShopCostumer?> GetByEmailAsync(string email, CancellationToken ct);
        Task AddAsync(ShopCostumer user, CancellationToken ct);
        Task SaveChangesAsync(CancellationToken ct);
        Task<ShopCostumer?> GetByIdAsync(int id, CancellationToken ct);
    }
}
