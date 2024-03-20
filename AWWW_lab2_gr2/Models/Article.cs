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
        public virtual Author ArticleAuthor {get; set;} = null!;
        public virtual Category ArticleCategory {get; set;} = null!;
        public virtual Match? AboutMatch {get; set;}
        public virtual ICollection<Comment>? Comments {get; set;}
        public virtual ICollection<Tag>? Tags {get; set;}
    }
}