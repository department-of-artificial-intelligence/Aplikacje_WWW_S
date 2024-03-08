using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab1_gr2.Models
{
    public class Article
    {
        public int Id {get;set;}
        public string Title{get;set;} = null!;
        public string Lead{get;set;} = null!;
        public string Content{get;set;} = null!;
        public DateTime CreationDate{get;set;} = null!;
        public Author? Author{get;set;} = null!;
        public IList<Tag>? Tags{get;set;} = null!;
        public Match? Match{get;set;}
    }
}