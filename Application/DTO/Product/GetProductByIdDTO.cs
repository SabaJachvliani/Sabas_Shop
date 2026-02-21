using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Product
{
    public class GetProductByIdDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
