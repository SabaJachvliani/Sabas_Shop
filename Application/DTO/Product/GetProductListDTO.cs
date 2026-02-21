namespace Application.DTO.Product
{
    public class GetProductListDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; } 
        public decimal Price { get; set; }
        public string? Description { get; set; } 
        public DateTime? DeleteTime { get; set; }
        
    }
}
