namespace Application.DTO.ProductCategory
{
    public class GetProductCategoryDTO
    {
        public int Id { get; set; }
        public string?  Name { get; set; }
        public List<ProductsInCategoryDTO> Products { get; set; } = new();
    }
}
