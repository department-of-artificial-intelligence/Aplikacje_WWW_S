using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr1.Models
{
    public class Order
    {
        [Key]
        public int Id {get;set;}

        public DateTime CreatedAt {get;set;}

        [ForeignKey("Customer")]
        public int CustomerId {get;set;}

        public virtual ICollection<OrderItem> OrderItems {get;set;} = new List<OrderItem>();

        [ForeignKey("Status")]
        public int OrderStatusId {get;set;}

        public virtual OrderStatus Status {get;set;}

        public virtual ICollection<OrderStatusHistory> History {get;set;}
    }
}