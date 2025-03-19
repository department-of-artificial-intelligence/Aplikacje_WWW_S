using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr3.Models
{
    public class EventType
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public list<MatchEvent> MatchEvents { get; set; }   
        
    }
}