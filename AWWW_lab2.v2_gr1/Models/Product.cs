namespace AWWW_lab2.v2_gr1.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [Column(TypeName = "decimal(18,4)")] 
        // trzeba doinstalowac EF dla innego formatu
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}