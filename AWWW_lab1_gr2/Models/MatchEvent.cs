namespace AWWW_lab1_gr2.Models{
public class MatchEvent
{ 
    public int Id {get; set;}
    public int Minute {get; set;}
    public Match Match {get; set;}=null!;
    public EventType EventType {get; set;}=null!;
    public MatchPlayer? MatchPlayer {get; set;}
}
}