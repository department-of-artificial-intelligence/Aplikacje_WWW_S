namespace AWWW_lab1_gr1.Models;
using Microsoft.EntityFrameworkCore;
public class MatchEvent{
    public int ID{get; set;}
    public int Minute{get; set;}
  
    public required Match Match { get; set; }

    public MatchPlayer? MatchPlayer { get; set; }

    public required EventType EventType { get; set; }
}
