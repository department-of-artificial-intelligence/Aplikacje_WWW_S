using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr3.Model
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Lead { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public ICollection<Comment> Comments { get; set; } = null!;
        public ICollection<Tag> Tags { get; set; } = null!;
        public Match? Match { get; set; }
    }
}