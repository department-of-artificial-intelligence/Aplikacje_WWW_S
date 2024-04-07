namespace AWWW_lab1_gr1.Models;
using Microsoft.EntityFrameworkCore;
public class EventType{
    public int ID{get; set;}
    public required string Name{get; set;}
    public List<MatchEvent>? MatchEvents { get; set; }
}