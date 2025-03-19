using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr3.Models
{
    public class MatchPlayer
    {
        public int Id { get; set; }
        public Datetime StartTime { get; set; }
        public Datetime EndTime { get; set; }

        public Player player{ get; set; }
        public int MatchPlayerId { get; set; }
        public list<MatchEvent>? MatchEvents { get; set; }
        public Match match { get; set; }
        public int MatchId { get; set; }

        public Position position{ get; set; }
        public int PositionId { get; set; }
    }
}