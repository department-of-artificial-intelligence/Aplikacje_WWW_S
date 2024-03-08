using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr2.Models
{
    public class League
    {
        public int Id {get; set;}
        public string? name {get; set;}
        public string? Coutry {get; set;}

        public virtual ICollection<Team> Teams {get; set;}
    }
}