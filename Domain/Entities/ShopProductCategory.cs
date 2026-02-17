namespace Domain.Entities
{
    public class ShopProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;    
        public List<ShopProduct> ShopProducts { get; set; } = new();

    }
}
