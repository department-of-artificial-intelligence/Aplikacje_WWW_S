using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab2_gr3.Models{
    public class Match{
        public int Id{get;set;}
        public DateTime Date{get;set;}
        public string Stadium{get;set;}
        public ICollection<MatchTeam> MatchTeams { get; set; }

        public ICollection<MatchEvent> MatchEvents { get; set; }

        public ICollection<MatchPlayer> MatchPlayers { get; set; }
    }
}