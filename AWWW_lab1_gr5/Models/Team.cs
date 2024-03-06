using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab1_gr5.Models
{
    public class Team
    {
        public int Id {get;set;}
        public string Name {get;set;}=null!;
        public string Country {get;set;}=null!;
        public string City {get;set;}=null!;
        public DateTime FoundingDate {get; set;}
    }
}