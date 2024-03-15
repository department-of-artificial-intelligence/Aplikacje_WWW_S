using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr2.Models
{
    public class MatchPlayer
    {
        public int Id {get; set;}
        public DateTime StartTime {get; set;}
        public DateTime EndTime {get; set;}
        public Match Match {get; set;} = null!;
        public ICollection<MatchEvent>? MatchEvents {get; set;}
        public Position Position {get; set;} = null!;
        public Player Player {get; set;} = null!;
    }
}