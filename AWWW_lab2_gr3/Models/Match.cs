using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr3.Models
{
    public class Match
    {
        public int MatchId { get; set; }
        public DateTime MatchDate { get; set; }

        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        public ICollection<MatchPlayer> MatchPlayers { get; set; }

        public ICollection<MatchEvent> MatchEvents { get; set; }
    }
}