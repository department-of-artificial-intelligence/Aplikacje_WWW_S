using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab1_gr2.Models
{
    public class Article
    {
        public int Id {get;set;}
        public string Title {get;set;} = null!;
        public string Lead {get;set;} = null!;
        public string Content {get;set;} = null!;
        public DateTime CreationDate {get;set;}
        public virtual Author Author {get;set;} = null!;
        public virtual Category Category {get;set;} = null!;
        public virtual ICollection<Comment>? Comments {get;set;}
        public virtual ICollection<Tag>? Tags {get;set;}
        public virtual ICollection<Match>? Matches {get;set;}
    }
}