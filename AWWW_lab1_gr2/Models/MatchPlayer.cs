using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab1_gr2.Models
{
    public class MatchPlayer
    {
        public int MatchPlayerId {get; set;}
        public DateTime StartTime {get; set;}
        public DateTime EndTime {get; set;}
        public ICollection<MatchEvent>? MatchEvents {get; set;}

    }
}