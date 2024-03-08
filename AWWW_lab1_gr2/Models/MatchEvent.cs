namespace AWWW_lab1_gr2.Models;
public class MatchEvent{
    public int Id;
    public int Minute;
    public int MatchId {get; set;}
    public Match Match {get; set;}=null!;
    public int? MatchPlayerId {get; set;}
    public MatchPlayer ?MatchPlayer {get; set;}
    public int EventTypeId {get; set;}
    public EventType EventType {get; set;}=null!;



}