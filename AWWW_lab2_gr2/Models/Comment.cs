using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr2.Models{
    public class Comment{
        public int Id {get; set;}
        public string Title {get; set;} = null!;
        public string Constent {get; set;} = null!;
        public virtual Article CommentedArticle {get; set;} = null!;
    }
}