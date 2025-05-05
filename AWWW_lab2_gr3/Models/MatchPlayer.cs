namespace AWWW_lab2_gr3.Models
{
    public class MatchPlayer
    {
        public int Id {get; set;}
        public DateTime StartTime { get; set;}
        public DateTime EndTime { get; set;}
        public Position Positions {get; set;}
        public Player Player {get; set;}
        public Match Match { get; set;}
        public MatchEvent? MatchEvent { get; set;}
    }
}