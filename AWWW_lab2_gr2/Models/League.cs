using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr2.Models
{
    public class League
    {
        public int Id{get;set;}
        public string Name{get;set;}
        public string Country{get;set;}
        public int Level{get;set;}
        public ICollection<Team>{get;set;}
        
    }
}