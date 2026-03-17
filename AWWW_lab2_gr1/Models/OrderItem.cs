using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AWWW_lab2_gr1.Models
{
    public class OrderItem
    {
        [Key]
        public int Id {get;set;}

        [ForeignKey("Order")]
        public int OrderId {get;set;}
        public Order Order {get;set;}

        [ForeignKey("Product")]
        public int ProductId {get;set;}
        public virtual Product Product {get;set;}

        public required int Quantity {get;set;}

        [Precision(18,4)]
        public required decimal UnitPrice {get;set;}
    }
}