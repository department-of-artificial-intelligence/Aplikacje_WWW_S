using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab2.Models
{
    public class Address
    {
        [Key]
        private int Id { get; set; }
        private int CustomerId {get; set; }
        [Required]
        private string City {get; set; }
        [Required]
        private string Street {get; set; }
        [Required]
        private string PostalCode {get; set; }

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