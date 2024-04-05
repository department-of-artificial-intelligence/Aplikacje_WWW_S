namespace AWWW_lab1_gr1.Models;
public class MatchPlayer{
    public int ID{get; set;}
    public DateTime StartTime{get;set;}
    public DateTime EndTime{get;set;}
    
    public required Player Player {get; set;}

    public required Match Match {get; set;}

    public required Position Position {get; set;}
}