using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr3.Models
{
    public class MatchEvent
    {
        public int MatchEventId { get; set; }

        public int MatchId { get; set; }
        public Match Match { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int EventTypeId { get; set; }
        public EventType EventType { get; set; }

        public int Minute { get; set; }
    }
}