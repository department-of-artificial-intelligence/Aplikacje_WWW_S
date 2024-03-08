using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab1_gr2.Models
{
    public class EventType
    {
        public int EventTypeId {get; set;}
        public string Name {get; set;} = null!; 
        public ICollection<MatchEvent>? MatchEvents {get; set;} 
    }
}