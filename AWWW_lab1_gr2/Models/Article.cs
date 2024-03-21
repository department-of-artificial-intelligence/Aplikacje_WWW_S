using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab1_gr2.Models
{
    public class Article
    {
        public int ArticleId {get; set;}
        public string? Title {get; set;} 
        public string? Content {get; set;}
        public DateTime CreationDate {get; set;}
        public Author Author {get; set;} = null!; 
        public ICollection<Comment>? Comments {get; set;}
        public Category Category {get; set;} = null!; 
        public ICollection<Tag>? Tags {get; set;}
        public Match? Match {get; set;}
    }
}