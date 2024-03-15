using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr2.Models{
    public class Article{
        
        public int Id {get; set;}
        public string Title {get; set;} = null!; 
        public string Lead {get; set;} = null!;
        public string Content {get; set;} = null!;
        public DateTime CreationDate {get; set;}
        public Author ArticleAuthor {get; set;} = null!;
        public Category ArticleCategory {get; set;} = null!;
        public Match? AboutMatch {get; set;}
        public ICollection<Comment>? Comments {get; set;}
        public ICollection<Tag>? Tags {get; set;}
    }
}