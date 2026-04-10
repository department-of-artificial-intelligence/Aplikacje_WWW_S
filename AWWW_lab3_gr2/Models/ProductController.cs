namespace AWWW_lab3_gr1.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductController
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; } //foreign key
    }
}