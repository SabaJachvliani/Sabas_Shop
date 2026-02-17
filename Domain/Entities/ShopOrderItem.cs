namespace Domain.Entities
{
    public class ShopOrderItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public ShopOrder ShopOrders { get; set; } = null!;

        public int ProductId { get; set; }
        public ShopProduct ShopProducts { get; set; } = null!;

    }
}
