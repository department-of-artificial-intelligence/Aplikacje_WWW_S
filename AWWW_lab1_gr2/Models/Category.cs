using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab1_gr2.Models
{
    public class Category
    {
        [DisplayName("Category Id")]
        public int CategoryId {get; set;}
        [DisplayName("Category Name")]

        public string? Name {get; set;}
        public ICollection<Article>? Articles {get; set;}
    }
}