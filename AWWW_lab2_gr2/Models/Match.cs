using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr2.Models
{
    public class Match
    {
        public int Id {get; set;}
        public DateTime Date {get; set;}
        public string Statium {get; set;} = null!;

        public List<Article> articles = new List<Article>();

        public Team[] teams = new Team[2];
    }
}