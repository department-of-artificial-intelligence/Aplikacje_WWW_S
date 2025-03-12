using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr3.Models
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Stadium { get; set; }
        public ICollection<Article> Articles { get; set; }

       
         public int TeamId1 { get; set; }
         public int TeamId2 { get; set; }

        public ICollection<Match> Matches { get; set; }
         
        
    }
}