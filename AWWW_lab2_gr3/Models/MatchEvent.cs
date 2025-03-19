using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr3.Models
{
    public class MatchEvent
    {
        public int id { get; set; }
        public int minute { get; set; }

        public int MatchPlayerId { get; set; }
        public virtual MatchPlayer ?matchPlayer{ get; set; }

        public int EventTypeId { get; set; }
        public virtual EventType eventType { get; set; }
    }
}