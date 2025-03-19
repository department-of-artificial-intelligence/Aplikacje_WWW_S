using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab2_gr3.Models{
    public class EventType{
        public int Id{get;set;}
        public string Name{get;set;}
        public ICollection<MatchEvent> MatchEvents { get; set; }
    }
}