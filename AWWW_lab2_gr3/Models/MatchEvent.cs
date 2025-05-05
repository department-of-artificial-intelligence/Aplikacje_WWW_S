namespace AWWW_lab2_gr3.Models
{
    public class MatchEvent
    {
        public int Id {get; set;}
        public int Minute {get; set;}
        public Match Match {get; set;}
        public ICollection<Player> MatchPlayers  { get; set;}
    }
}