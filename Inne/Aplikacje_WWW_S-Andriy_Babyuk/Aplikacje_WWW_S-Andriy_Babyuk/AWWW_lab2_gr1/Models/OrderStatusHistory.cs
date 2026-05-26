using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AWWW_lab2_gr1.Models
{
    public class OrderStatusHistory
    {
        [Key]
        public int Id {get;set;}

        [ForeignKey("Order")]
        public int OrderId {get;set;}
        public virtual Order Order {get;set;}

        [ForeignKey("Status")]
        public int OrderStatusId {get;set;}
        public virtual OrderStatus Status {get;set;}

        public DateTime ChangedAt {get;set;}
    }
}