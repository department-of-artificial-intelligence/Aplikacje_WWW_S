using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr3.Model
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Stadium { get; set; } = null!;
        public ICollection<Article> Articles { get; set; } = null!;
        public ICollection<MatchPlayer> MatchPlayers { get; set; } = null!;
        public ICollection<MatchEvent> MatchEvents { get; set; } = null!;
        public Team HomeTeam { get; set; } = null!;
        public Team AwayTeam { get; set; } = null!;
    }
}