using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab2.Models
{
    public class CustomerProfile
    {
        
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Phone { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;


        public CustomerProfile()
    {
    }

    public CustomerProfile(int id, int customerId, string phone, DateTime dateOfBirth)
    {
        Id = id;
        CustomerId = customerId;
        Phone = phone;
        DateOfBirth = dateOfBirth;
    }
    }
}