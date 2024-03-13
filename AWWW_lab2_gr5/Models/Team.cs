using System.Net.NetworkInformation;

namespace AWWW_lab1_gr5.Models{
    public class Team{
        public int Id {get;set;}
        public string Name {get;set;}
        public string Country {get;set;}
        public string City {get;set;}
        public DateTime FoundingDate {get;set;}
        public virtual ICollection<Match> Matches {get;set;}
        public virtual ICollection<Player> Players {get;set;}
        public int LeagueId {get;set;}
        public virtual League League {get;set;}


    }
}