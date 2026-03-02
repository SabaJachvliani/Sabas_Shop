namespace Domain.Entities
{    

    public class ShopProductPhoto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public ShopProduct Product { get; set; } = null!;

        public string Url { get; set; } = null!;  
        public int Order { get; set; }             
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
