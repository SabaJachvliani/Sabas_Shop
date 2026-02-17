namespace Domain.Entities
{
    public class ShopCostumer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PersonalId { get; set; }

        public List<ShopOrder> ShopOrders { get; set; } = new();
        public List<ShopCastumersInformation> CastumersInformations { get; set; } = new();

    }
}
