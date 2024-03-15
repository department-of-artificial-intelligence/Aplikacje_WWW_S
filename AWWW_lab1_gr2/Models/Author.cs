using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab1_gr2.Models
{
    public class Author
    {
        [DisplayName("Author id")]
        public int AuthorId {get; set;}

        [DisplayName("First Name")]
        public string? FirstName {get; set;}
        [DisplayName("Last Name")]
        public string? LastName {get; set;}
        public ICollection<Article>? Articles {get; set;}


    }
}