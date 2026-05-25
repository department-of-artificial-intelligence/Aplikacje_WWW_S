using System.Collections.Generic;

namespace Kolokwium.Services.DTO.Product
{
    public class CreateProductDto
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public List<int> TagIds { get; set; } = new();
    }
}