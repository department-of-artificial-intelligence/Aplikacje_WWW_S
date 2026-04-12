using System.ComponentModel.DataAnnotations;

namespace AWWW_lab2_gr1.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}