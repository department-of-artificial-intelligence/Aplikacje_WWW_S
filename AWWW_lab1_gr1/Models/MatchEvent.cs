namespace AWWW_lab1_gr1.Models
{
    public class MatchEvent
    {
        public int Id { get; set; }
        public int Minute { get; set; }
        public int EventTypeId { get; set; }
        public int MatchId { get; set; }
        public int? MatchPlayerId { get; set; }

        public EventType EventType { get; set; } = null!;
        public Match Match { get; set; } = null!;
        public MatchPlayer? MatchPlayer { get; set; }
    }
}
