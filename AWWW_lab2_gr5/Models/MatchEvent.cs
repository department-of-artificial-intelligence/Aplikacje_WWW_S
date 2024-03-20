namespace AWWW_lab1_gr5.Models
{
    public class MatchEvent
    {
        public int Id { get; set; }
        public int Minute { get; set; }

        public int MatchId { get; set; }
        public Match Match { get; set; }
        public int EventTypeId { get; set; }
        public EventType EventType { get; set; }
        public int MatchPlayerId { get; set; }
        public MatchPlayer? MatchPlayer { get; set; }

    }
}