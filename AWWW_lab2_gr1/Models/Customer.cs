using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;


namespace AWWW_lab2_gr1.Models
{
    public class Customer
    {
        [Key]
        public int Id {get; set;}
        public required string Name {get; set;}

        public CustomerProfile CustomerProfile {get;set;}

        public List<Address> Addresses {get;set;} = new();
        public List<Review> Reviews {get;set;} = new();
        public List<Order> Orders {get;set;} = new();
    }
}