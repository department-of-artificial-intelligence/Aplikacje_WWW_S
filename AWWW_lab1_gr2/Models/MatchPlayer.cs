using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab1_gr2.Models
{
    public class MatchPlayer
    {
        public int ID{get;set;}
        public DateTime StartTime{get;set;}
        public DateTime EndTime{get;set;}
        public Player Player{get;set;} = null!;
        public Position Postition{get;set;} = null!;
        public Match Match{get;set;} = null!;
    }
}