using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr2.Models
{
    public class MatchPlayer
    {
        public int Id{get;set;}
        public DateTime EndTame{get;get;}
        public Icollection<MatchEvent> event{get;set;}
        public  Match  mecz {get;set;}
        public  Position position{get;set;}
        public Player player{get;set;}
        
    }
}