using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr2.Models
{
    public class Match
    {
        public int Id {get; set;}
        public DateTime Date {get; set;}
        public string Statium {get; set;} = null!;


        public int HomeTeamId {get; set;}
        public int AwayTeamId {get; set;}
        public virtual ICollection<Article>? articles {get;set;}
        public virtual Team HomeTeam{get;set;} = null!;
        public virtual Team AwayTeam{get;set;} = null!;
        public virtual ICollection<MatchEvent>? matchEvents {get;set;}
        public virtual ICollection<MatchPlayer>? matchPlayers {get;set;}
    }
}