using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace AWWW_lab1_gr5.Controllers
{
    public class Team
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public string Country {get;set;}
        public string City {get;set;}
        public DateTime FoundingTime {get;set;}

        public int LeagueId{get;set;}
        public virtual League League {get;set;}
        public virtual ICollection<Player> Players {get;set;}
        public virtual ICollection<Match> Matches {get;set;}

        

    }
}