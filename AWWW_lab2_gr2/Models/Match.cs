using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr2.Models
{
    public class Match
    {
        public int Id {get; set;}
        public DateTime Date{get;set;}
        public string stadium{get;set;}
        public ICollection<Articles>? artykuly {get;set;}
        public ICollection<Team> teams{get;set}
    }
}