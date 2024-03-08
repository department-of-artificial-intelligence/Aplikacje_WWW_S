using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace AWWW_lab1_gr2.Models
{
    public class MatchEvent
    {
        public int ID{get;set;}
        public int Minute{get;set;}
        public Match Match{get;set;} = null!;
        public EventType EventType{get;set;} = null!;
        public MatchPlayer? MatchPlayer{get;set;}
    }
}