namespace AWWW_lab1_gr1.Models
{
    public class MatchPlayer
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int PlayerId { get; set; }
        public int PositionId { get; set; }
        public int MatchId { get; set; }

        public Player Player { get; set; } = null!;
        public Position Position { get; set; } = null!;
        public Match Match { get; set; } = null!;
        public ICollection<MatchEvent>? MatchEvents { get; set; }
    }
}
