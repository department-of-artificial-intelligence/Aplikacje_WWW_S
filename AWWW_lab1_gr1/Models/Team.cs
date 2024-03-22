using System.Net.NetworkInformation;

namespace AWWW_lab1_gr1.Models{
    public class Team{
        public int ID{get; set;}
        public required string Name{get;set;}
        public required string Country{get;set;}
        public required string City{get;set;}
        public DateTime FoundingDate{get;set;}
        public virtual ICollection<Match> HomeMatches { get; set; }
        public virtual ICollection<Match> AwayMatches { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual League League { get; set; }
        public int LeagueID{get; set;}
    }
}