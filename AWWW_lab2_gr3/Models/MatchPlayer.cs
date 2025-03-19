using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab2_gr3.Models{
    public class MatchPlayer{
        public int Id{get;set;}
        public DateTime StartTime{get;set;}
        public DateTime EndTime{get;set;}
        public int MatchId { get; set; }
        public Match Match { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }

        public ICollection<MatchEvent> MatchEvents { get; set; }
    }
}