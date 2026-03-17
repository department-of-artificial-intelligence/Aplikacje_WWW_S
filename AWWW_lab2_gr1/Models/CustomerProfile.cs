using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr1.Models
{
    public class CustomerProfile
    {
        [Key]
        public int Id {get;set;}

        [ForeignKey("Customer")]
        public int CustomerId {get;set;}
        public virtual Customer Customer {get;set;}
        public string? Phone {get;set;}
        public DateTime? DateOfBirth {get;set;}
    }
}