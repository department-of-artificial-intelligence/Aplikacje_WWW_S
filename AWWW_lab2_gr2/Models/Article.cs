using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr2.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Lead { get; set; }
        public string? Content { get; set; }
        public DateTime CreationDate { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<ArticleTag> ArticleTags { get; set;}

        public int MatchId { get; set; }
        public virtual Match Match { get; set; }

        
    }
}