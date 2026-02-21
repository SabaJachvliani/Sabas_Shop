namespace Domain.Entities
{
    public class ShopCostumer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;        
        public string Role { get; set; } = "User";
        public string Mail { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        

        public List<ShopOrder> ShopOrders { get; set; } = new();
        public List<ShopCastumersInformation> CastumersInformations { get; set; } = new();

    }
}
