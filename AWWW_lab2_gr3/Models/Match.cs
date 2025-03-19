using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr3.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int Minute { get; set; }

        public list<Article> Articles { get; set; }
        public Team HomeTeam { get; set; }
        public int HomeTeamId { get; set; }

        public Team AwayTeam { get; set; }
        public int AwayTeamId { get; set; }

        public list<MatchEvent> MatchEvents { get; set; }

        public list<MatchPlayer> MatchPlayers { get; set; }

        

    }
}