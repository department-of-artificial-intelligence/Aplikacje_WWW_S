using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab2.Models
{
    public class CustomerProfile
    {
        private int Id { get; set; }
        private int CustomerId {get; set;}
        
        [Required]
        private string Phone {get; set;}
        [Required]
        private DateTime DateOfBirth {get; set;}


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