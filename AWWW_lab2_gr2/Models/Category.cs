using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr2.Models
{
    public class Category
    {
        public int Id {get; set;}
        public string Name {get;set;} = null!;

        public List<Article> articles = new List<Article>();
    }
}