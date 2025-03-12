using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Model.DataModels
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Lead { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
