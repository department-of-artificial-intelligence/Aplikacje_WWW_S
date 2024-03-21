namespace AWWW_lab1_gr1.Models;


public class MatchEvent {
     public required Match Match { get; set; }
    public MatchPlayer MatchPlayer { get; set; }
    public required EventType EventType { get; set; }
    public int Id { get; set; }
    public required int Minute { get; set; }

    

}
