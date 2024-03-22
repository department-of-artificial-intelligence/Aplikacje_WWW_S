using System.Net.NetworkInformation;

namespace AWWW_lab1_gr1.Models{
    public class Match{
        public int ID{get; set;}
        public required string Stadium{get;set;}
        public DateTime Date{get;set;}
         virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<MatchPlayer> MatchPlayers { get; set; }
        public virtual ICollection<MatchEvent> MatchEvents { get; set; }
        public int HomeTeamID {get; set;}
        public int AwayTeamID {get; set;}
        public virtual Team HomeTeam {get; set;}
        public virtual Team AwayTeam {get; set;}
    }
}