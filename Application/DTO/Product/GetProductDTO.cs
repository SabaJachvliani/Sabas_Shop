namespace Application.DTO.Product
{
    public class GetProductDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; } 
        public decimal Price { get; set; }
        public string? Description { get; set; }        
        public DateTime? DeleteTime { get; set; }
        public ProductCategoryDTO? Category { get; set; }

    }
}
