namespace AWWW_lab2_gr3.Models
{
    public class MatchPlayer
    {
        public int Id {get; set;}
        public DateTime StartTime { get; set;}
        public DateTime EndTime { get; set;}
        public virtual ICollection<Position> Positions {get; set;}
        public virtual Match Match { get; set;}
        public int MatchId {get; set;}
        public virtual MatchEvent? MatchEvent { get; set;}
        public int MatchEventId {get; set;}
    }
}