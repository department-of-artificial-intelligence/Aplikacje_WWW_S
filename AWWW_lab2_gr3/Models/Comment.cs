using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr3.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content{ get; set; }

        public Article article{ get; set; }
        public int ArticleId { get; set; }
    }
}