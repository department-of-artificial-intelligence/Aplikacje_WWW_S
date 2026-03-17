using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr1.Models
{
    public class OrderItem
    {
        [Key]
        public int Id {get;set;}

        [ForeignKey("Order")]
        public int OrderId {get;set;}
    }
}