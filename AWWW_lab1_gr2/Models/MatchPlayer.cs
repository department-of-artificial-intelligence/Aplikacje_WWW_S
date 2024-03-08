namespace AWWW_lab1_gr2.Models;
public class MatchPlayer{
    public int Id;
    public DateTime StartTime;
    public DateTime EndTime;
    public int PositionId {get; set;}
    public Position Position {get; set;}=null!;
    public int PlayerId {get; set;}
    public Player Player {get; set;}=null!;


}