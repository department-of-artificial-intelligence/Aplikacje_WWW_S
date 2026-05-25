using System.Collections.Generic;

namespace Kolokwium.Services.DTO.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string CategoryName { get; set; } = null!;
        public List<string> Tags { get; set; } = new();
    }
}