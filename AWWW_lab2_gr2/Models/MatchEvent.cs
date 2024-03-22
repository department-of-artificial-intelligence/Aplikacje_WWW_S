using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr2.Models
{
    public class MatchEvent
    {
        public int Id{get;set;}
        public int Minute {get;set;}
        public EventType type{get;set;}
        public MatchPlayer? matchplayer {get;set;}
        
    }
}