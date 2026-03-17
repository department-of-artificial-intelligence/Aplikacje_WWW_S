using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr1.Models
{
    public class Review
    {
        [Key]
        public int Id {get;set;}

        [ForeignKey("Product")]
        public int ProductId {get;set;}
        public Product Product {get;set;}
        [ForeignKey("Customer")]
        public int CustomerId {get;set;}
        public Customer Customer {get;set;}
        public required int Rating {get;set;}
        public string? Comment {get;set;}
    }
}