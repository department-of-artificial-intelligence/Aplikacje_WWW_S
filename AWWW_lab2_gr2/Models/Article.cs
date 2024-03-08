using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr2.Models
{
    public class Article
    {
        public int Id {get; set;}
        public string Title {get;set;} = null!;
        public string Lead {get;set;} = null!;
        public string Content {get;set;} = null!;
        public DateTime CreationDate {get;set;}

        public List<AWWW_lab2_gr2.Models.Comment> comments = new List<Comment>();
        public AWWW_lab2_gr2.Models.Author author{get;set;} = null!;
        public AWWW_lab2_gr2.Models.Category categories{get;set;} = null!;
        public List<AWWW_lab2_gr2.Models.Tag> tags = new List<Tag>();
        public Match? match {get; set;}
    }
}