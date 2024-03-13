using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace AWWW_lab1_gr5.Controllers
{
    public class MatchPlayer
    {
        public int Id {get;set;}
        public DateTime StartTime {get;set;}
        public DateTime EndTime {get;set;}

        public int MatchId {get;set;}
        public Match Match {get;set;}
        public int PlayerId {get;set;}
        public virtual Player Player {get;set;}
        public int PositionId {get;set;}
        public virtual Position Position {get;set;}
        

    }
}