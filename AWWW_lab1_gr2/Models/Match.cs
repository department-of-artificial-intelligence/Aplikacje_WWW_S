using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab1_gr2.Models
{
    public class Match
    {
        public int ID{get;set;}
        public DateTime Date{get;set;}
        public string? Stadium{get;set;}
        public Team HomeTeam{get;set;} = null!;
        public Team NotHomeTeam{get;set;} = null!;
    }
}