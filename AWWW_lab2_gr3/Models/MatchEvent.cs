using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr3.Models
{
    public class MatchEvent
    {
        public int Id { get; set; }
        public int Minute { get; set; }

        public EventType eventType { get; set; }
        public int EventId { get; set; }
        public MatchPlayer matchPlayer{ get; set; }
        public int MatchPlayerId { get; set; }

        public Match match { get; set; }
        public int intMatchId { get; set; }
    }
}