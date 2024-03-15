using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr2.Models{
    public class MatchEvent{
        public int Id {get; set;}
        public int Minute {get; set;}
        public Match Match {get; set;} = null!;
        public MatchPlayer? MatchPlayer {get; set;}
        public EventType EventType {get; set;} = null!;
    }
}