using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr2.Models
{
    public class Article
    {
        public int Id {get; set;}
        public string Title {get;set;} = null!;
        public string Lead {get;set;} = null!;
        public string Content {get;set;} = null!;
        public DateTime CreationDate {get;set;}

        public virtual ICollection<Comment>? comments {get;set;}
        public virtual Author author {get;set;} = null!;
        public virtual Category categories{get;set;} = null!;
        public virtual ICollection<Tag>? tags {get;set;}
        public virtual Match? match {get; set;}
    }
}