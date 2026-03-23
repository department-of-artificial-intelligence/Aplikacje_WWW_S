using System.ComponentModel.DataAnnotations;

namespace AWWW_lab2_gr1.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        
        [Range(1, 5)]
        public int Rating { get; set; }
        
        public string? Comment { get; set; }

        public Product? Product { get; set; }
        public Customer? Customer { get; set; }
    }
}