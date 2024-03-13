using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace AWWW_lab1_gr5.Controllers
{
    public class MatchEvent
    {
        public int Id {get;set;}
        public int Minute {get;set;}

        public int MatchId {get;set;}
        public Match Match {get;set;}
        public int EventTypeId{get;set;}
        public EventType EventType {get;set;}
        public MatchPlayerId{get;set;}
        public MatchPlayer ? MatchPlayer{get;set;}
        
    }
}