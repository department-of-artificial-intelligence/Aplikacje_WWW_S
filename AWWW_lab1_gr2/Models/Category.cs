using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab1_gr2.Models
{
    public class Category
    {
        public int ID{get;set;}
        public string Name{get;set;} = null!;
        public IList<Article>? Articles{get;set;}
    }
}