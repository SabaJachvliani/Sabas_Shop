namespace Domain.Entities.RefreshToken
{
    public class ShopRefreshToken
    {
        public long Id { get; set; }

        public int UserId { get; set; }               // your ShopCostumer Id type = int
        public ShopCostumer User { get; set; } = null!;

        public string TokenHash { get; set; } = null!;
        public DateTime CreatedAtUtc { get; set; }
        public DateTime ExpiresAtUtc { get; set; }

        public DateTime? RevokedAtUtc { get; set; }
        public string? ReplacedByTokenHash { get; set; }

        public bool IsActive => RevokedAtUtc == null && DateTime.UtcNow < ExpiresAtUtc;
    }
}
