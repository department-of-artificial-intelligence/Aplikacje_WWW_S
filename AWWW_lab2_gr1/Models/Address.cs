using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr1.Models
{
    public class Address
    {
        [Key]
        public int Id {get;set;}

        [ForeignKey("Customer")]
        public int CustomerId {get;set;}

        public virtual Customer Customer {get;set;}

        public required string City {get;set;}
        public string? Street {get;set;}
        public string? PostalCode {get;set;}
    }
}