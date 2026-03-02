namespace Application.DTO.ProductCategory
{
    public class ProductsInCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public DateTime? DeleteTime { get; set; }
    }
}
