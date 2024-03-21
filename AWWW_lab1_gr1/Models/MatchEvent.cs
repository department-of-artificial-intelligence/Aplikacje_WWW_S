namespace AWWW_lab1_gr1.Models;
public class MatchEvent {
    public int Id { get; set; }

    public int Minute { get; set; }

    public required Match Match { get; set; }

    public int MatchId { get; set; }
    public MatchPlayer? MatchPlayer { get; set; }

    public required EventType EventType { get; set; }

    

}