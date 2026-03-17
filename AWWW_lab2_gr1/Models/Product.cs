using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr1.Models
{
    public class Product
    {
        [Key]
        public int Id {get;set;}
        public required string Name {get;set;}
        
        [Precision(18,4)]
        public required decimal Price {get;set;}

        [ForeignKey("Category")]
        public int CategoryId {get;set;}
        public virtual Category Category {get;set;}

        public virtual ICollection<Tag> Tags {get;set;} = new();
        public virtual ICollection<OrderItem> OrderItems {get;set;} = new();
        public virtual ICollection<Review> Reviews {get;set;} = new();
    }
}