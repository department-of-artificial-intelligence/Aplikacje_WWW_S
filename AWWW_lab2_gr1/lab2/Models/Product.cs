using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Models
{
    public class Product
    {
        private int Id { get; set; }
        [Required]
        private string Name {get; set;}
        [Required]
        private decimal Price {get; set; }

    }
}