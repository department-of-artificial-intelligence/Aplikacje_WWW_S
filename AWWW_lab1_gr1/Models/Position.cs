using System.Net.NetworkInformation;

namespace AWWW_lab1_gr1.Models{
    public class Position{
        public int ID{get; set;}
        public required string Name{get;set;}
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<MatchPlayer> MatchPlayers { get; set; }
    }
}