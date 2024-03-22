using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr2.Models
{
    public class Match
    {
        public int Id {get; set;}
        public DateTime Date{get;set;}
        public string stadium{get;set;}
        public Team HomeTeam{get;set;}=null!;
        public Team AwayTeam{get;set;}=null!;
        public ICollection<Articles>? artykuly {get;set;}
        public ICollection<MatchPlayer> matchplayer{get;set}
        public ICollection<MatchEvent> events{get;set}
    }
}