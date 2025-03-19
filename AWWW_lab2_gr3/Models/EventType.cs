using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr3.Models
{
    public class EventType
    {
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<MatchEvent> matchEvents { get; set; }
    }
}