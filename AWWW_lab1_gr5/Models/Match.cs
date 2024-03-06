using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab1_gr5.Models
{
    public class Match
    {
        public int Id {get; set;}
        public DateTime Date {get; set;}
        public string Stadium {get; set;} = null!;
        public int ArticleId {get; set;}
        public virtual Article? Article {get; set;}
        public virtual ICollection<MatchPlayer>? MatchPlayers {get; set;}
        public virtual ICollection<MatchEvent>? MatchEvents {get; set;}
        public virtual ICollection<Team> Teams {get; set;} = null!;

    }
}