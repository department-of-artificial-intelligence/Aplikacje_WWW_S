namespace AWWW_lab1_gr1.Models
{
    public class MatchEvent
    {
        public int Id { get; set; }
        public string Minute { get; set; } = null!;
        public Match Match { get; set; } = null!;
        public MatchPlayer? MatchPlayer { get; set; }
        public EventType EventType { get; set; } = null!;
    }
}
