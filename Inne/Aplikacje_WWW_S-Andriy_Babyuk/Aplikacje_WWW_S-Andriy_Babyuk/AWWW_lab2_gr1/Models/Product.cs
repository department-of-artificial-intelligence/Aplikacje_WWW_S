using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AWWW_lab2_gr1.Models
{
    public class Product
    {
        [Key]
        public int Id {get;set;}

        [DisplayName("Name")]
        public string Name {get;set;} = "";
        
        [DisplayName("Price")]
        [Precision(18,4)]
        public decimal Price {get;set;} = 0;

        [DisplayName("Category")]
        [ForeignKey("Category")]
        public int CategoryId {get;set;}
        public virtual Category Category {get;set;}

        public virtual ICollection<Tag> Tags {get;set;} = new List<Tag>();
        public virtual ICollection<OrderItem> OrderItems {get;set;} = new List<OrderItem>();
        public virtual ICollection<Review> Reviews {get;set;} = new List<Review>();
    }
}