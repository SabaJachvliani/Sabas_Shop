namespace Domain.Entities
{
    public class ShopOrder
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public int CostumerId { get; set; }
        public ShopCostumer ShopCostumers { get; set; } = null!;
        public List<ShopOrderItem> ShopOrderItems { get; set; } = new();

    }
}
