using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab1_gr2.Models
{
    public class MatchEvent
    {
        public int MatchEventId {get; set;}
        public int Minute {get; set;}
        public Match Match {get; set;} = null!; 
        public MatchPlayer? MatchPlayer {get; set;}
        public EventType EventType {get; set;} =null!; 
    }
}