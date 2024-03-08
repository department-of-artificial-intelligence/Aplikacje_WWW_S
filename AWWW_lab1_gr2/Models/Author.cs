using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab1_gr2.Models
{
    public class Author
    {
        public int AuthorId {get; set;}
        public string? FirstName {get; set;}
        public string? LastName {get; set;}
        public ICollection<Article>? Articles {get; set;}


    }
}