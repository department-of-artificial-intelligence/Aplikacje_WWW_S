using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr3.Models
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Stadium { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<MatchEvent> MatchEvents { get; set; }
        public ICollection<MatchPlayer> MatchPlayers { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
    }
}