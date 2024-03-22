using System.Net.NetworkInformation;

namespace AWWW_lab1_gr1.Models{
    public class Player{
        public int ID{get; set;}
        public required string FirstName{get;set;}
        public required string LastName{get;set;}
        public required string Country{get;set;}
        public int TeamID{get;set;}
        public int PositionID{get;set;}
        public virtual ICollection<Position> Positions { get; set; }
        public virtual ICollection<MatchPlayer> MatchPlayers { get; set; }
        public virtual Team Team { get; set; }
        public DateTime BirthDate{get;set;}
    }
}