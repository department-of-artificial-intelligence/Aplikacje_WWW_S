using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr3.Models
{
    public class Articles
    {
        public int Id { get; set; }
        public string Title { get; set; }
         public string Lead { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public Author author{ get; set; }
        public int AuthorId { get; set; }

        public Category category{ get; set; }
        public int CategoryId { get; set; }
        public list<Tag> tags{ get; set; }

        public Match? match{ get; set; }
        public int? MatchId { get; set; }


    }
}