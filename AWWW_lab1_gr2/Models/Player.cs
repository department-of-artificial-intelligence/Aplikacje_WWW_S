using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace AWWW_lab1_gr2.Models
{
    public class Player
    {
        public int ID{get;set;}
        public string FirstName{get;set;} = null!;
        public string LastName{get;set;} = null!;
        public string? Country{get;set;}
        public DateTime BirthDate{get;set;}
        public IList<Position> Positions{get;set;} = null!;
        public Team? Team{get;set;}
    }
}