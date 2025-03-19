using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab2_gr3.Models{
    public class Article{
        public int Id{get;set;}
        public string Title{get;set;}
        public string Lead{get;set;}
        public string Content{get;set;}
        public DateTime CreationDate{get;set;}

         public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<ArticleTag> ArticleTags { get; set; }
    }
}