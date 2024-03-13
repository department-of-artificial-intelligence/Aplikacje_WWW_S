using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace AWWW_lab1_gr5.Controllers
{
    public class Match
    {
        public int Id {get;set;}
        public DateTime Date {get;set;}
        public string Stadium {get;set;}

        public virtual ICollection<Article> Articles {get;set;}
        public virtual ICollection<MatchEvent> MatchEvents {get;set;}
        public virtual ICollection<MatchPlayer> MatchPlayers {get;set;}
        public int HomeTeamId {get;set;}
        public int AwayTeamId {get;set;}
        public virtual Team HomeTeam {get;set;}
        public virtual Team AwayTeam{get;set;}


    }
}