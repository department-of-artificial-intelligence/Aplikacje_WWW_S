namespace AWWW_lab3_gr2.Models;
using System.Data;

public class EventType
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<MatchEvent>? MatchEvents { get; set; }
}