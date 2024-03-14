using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr2.Models
{
    public class MatchEvent
    {
        public int Id { get; set; }
        public int Minute { get; set; }
        public virtual Match Match { get; set; }
        public virtual MatchPlayer Player { get; set; }
        public virtual EventType EventType { get; set; }

        public virtual ICollection<MatchEvent> MatchEvents { get; set; }
    }
}