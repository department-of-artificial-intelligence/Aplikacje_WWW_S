using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr2.Models
{
    public class ArticleTag
    {
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }

        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}