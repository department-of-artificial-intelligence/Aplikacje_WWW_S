namespace AWWW_lab2_gr3.Models;

public class EventType
{
    public int Id {get; set;}
    public string Name {get; set;}

    public List<MatchEvent> MatchEvents {get; set;}
}