namespace AWWW_lab1_gr1.Models;

public class EventType
{
    public int Id{get;set;}

    public required string Name{get;set;}

    public  required ICollection<MatchEvent> MatchEvents{get;set;}

}