using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr3.Models
{
    public class Author
    {
        public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
    }
}