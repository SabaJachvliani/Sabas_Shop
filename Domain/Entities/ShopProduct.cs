namespace Domain.Entities
{
    public class ShopProduct
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public DateTime? DeleteTime { get; set; } 

        public int Product_CategoryId { get; set; }
        public ShopProductCategory ShopProductCategorys { get; set; } = null!;

        public List<ShopOrderItem> ShopOrderItems { get; set; } = new();

    }
}
