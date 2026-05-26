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

        public virtual CustomerProfile CustomerProfile {get;set;}

        [ForeignKey("Address")]
        public int AddressId {get;set;}
        public virtual Address Address {get;set;}
        public virtual ICollection<Review> Reviews {get;set;} = new List<Review>();
        public virtual ICollection<Order> Orders {get;set;} = new List<Order>();
    }
}