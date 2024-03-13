using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace AWWW_lab1_gr5.Controllers
{
    public class League
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public string Country {get;set;}
        public int Level {get;set;}
        public virtual ICollection<Team> Teams{get;set;}
        

    }
}