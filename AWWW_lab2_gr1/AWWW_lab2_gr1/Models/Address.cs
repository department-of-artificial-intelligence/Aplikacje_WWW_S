using AWWW_lab2_gr1.Models;
using System.ComponentModel.DataAnnotations;

namespace AWWW_lab2_gr1.Models
{
    public class Address
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [Required]
        public string City { get; set; } = null!;

        [Required]
        public string Street { get; set; } = null!;

        [Required]
        public string PostalCode { get; set; } = null!;

        public Customer Customer { get; set; } = null!;
    }
}