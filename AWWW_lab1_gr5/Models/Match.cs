using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab1_gr5.Models
{
    public class Match
    {
        public int Id {get; set;}
        public DateTime Date {get;set;}
        public string Stadium {get;set;}=null!;
    }
}