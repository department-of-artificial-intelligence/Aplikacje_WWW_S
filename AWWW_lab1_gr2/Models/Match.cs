using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab1_gr2.Models
{
    public class Match
    {
        public int MatchId {get; set;}
        public DateTime Date {get; set;}
        public string? Stadium {get; set;}

        public ICollection<Article>? Articles {get; set;}
        public Team HomeTeam {get; set;} =null!; 
        public Team AwayTeam {get; set;} = null!; 

        public int HomeTeamId {get; set;}
        public int AwayTeamId {get; set;}
    }
}