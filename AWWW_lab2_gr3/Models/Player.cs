using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr3.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }

        public ICollection<MatchPlayer> MatchPlayers { get; set; }
        public ICollection<MatchEvent> MatchEvents { get; set; }
    }
}