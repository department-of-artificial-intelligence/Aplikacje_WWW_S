using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace AWWW_lab2_gr1.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public CustomerProfile? CustomerProfile { get; set; }

        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}