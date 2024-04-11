namespace AWWW_lab1_gr1.Models;


public class MatchEvent {
     public Match Match { get; set; } = null!;
    public MatchPlayer? MatchPlayer { get; set; }
    public EventType? EventType { get; set; }
    public int Id { get; set; }
    public int Minute { get; set; }

     

}
