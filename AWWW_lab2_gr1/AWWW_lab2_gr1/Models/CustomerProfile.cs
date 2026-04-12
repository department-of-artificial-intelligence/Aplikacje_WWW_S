using System.ComponentModel.DataAnnotations;

namespace AWWW_lab2_gr1.Models

{
    public class CustomerProfile
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [Required]
        public string Phone { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        public Customer Customer { get; set; } = null!;
    }
}