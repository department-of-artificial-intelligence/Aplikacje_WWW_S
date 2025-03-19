namespace AWWW_lab2_gr3.Models;

public class MatchPlayer
{
    public int Id {get; set;}
    public DateTime StartTime {get; set;}
    public DateTime EndTime {get; set;}

    public List<MatchEvent> MatchEvents {get; set;}

    public int MatchId {get; set;}
    public Match Match {get; set;}

    public int PlayerId {get; set;}
    public Player Player {get; set;}

    public int PositionId {get; set;}
    public Positon Positon {get; set;}
}