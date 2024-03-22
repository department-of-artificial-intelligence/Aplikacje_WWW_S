namespace AWWW_lab1_gr1.Models;
public class MatchPlayer
{
    public int Id { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public int MatchId { get; set; }
    public Match Match { get; set; } = null!;

    public int PositionId { get; set; }
    public Position Position { get; set; } = null!;
    

    public  ICollection<MatchEvent>? MatchEvents { get; set; }


}