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

        public int HomeTeamId { get; set; }
  
         public virtual Team HomeTeam { get; set; }
        public int AwayTeamId { get; set; }
         public virtual Team AwayTeam { get; set; }
         public MatchPlayer matchPlayer{ get; set; }
         public ICollection<MatchEvent> matchEvents { get; set; }
        
    }
}