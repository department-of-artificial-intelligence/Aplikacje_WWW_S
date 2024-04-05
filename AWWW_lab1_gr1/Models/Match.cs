using System.Net.NetworkInformation;
using System.ComponentModel.DataAnnotations;

namespace AWWW_lab1_gr1.Models{
    public class Match{
        public int ID{get; set;}
        public required string Stadium{get;set;}
        public DateTime Date{get;set;}
        public required ICollection<MatchPlayer> MatchPlayers { get; set; }
        public required ICollection<MatchEvent> MatchEvents { get; set; }
        public int HomeTeamID {get; set;}
        public int AwayTeamID {get; set;}
        public virtual Team HomeTeam {get; set;} = null!;
        public virtual Team AwayTeam {get; set;} = null!;
    }
}