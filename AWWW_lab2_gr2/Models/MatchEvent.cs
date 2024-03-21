using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr2.Models
{
    public class MatchEvent
    {
        public int Id {get; set;}
        public int Minute {get; set;}

        public virtual Match match {get;set;} = null!;
        public virtual EventType eventType {get;set;} = null!;
        public virtual MatchPlayer? matchPlayer {get;set;}
    }
}