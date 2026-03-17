using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab2.Models
{
    public class Address
    {
        
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string Street { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string PostalCode { get; set; } = null!;


        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;


        public Address()
        {
        }

    public Address(int id, int customerId, string city, string street, string postalCode)
    {
        Id = id;
        CustomerId = customerId;
        City = city;
        Street = street;
        PostalCode = postalCode;
    }

    }
}