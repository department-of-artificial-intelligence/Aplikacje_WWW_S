namespace AWWW_lab1_gr1.Models;
public class MatchPlayer
{
    public int Id { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public int MatchId { get; set; }
    public Match Match { get; set; } = null!;

    public int PositionId { get; set; }
    public Match Position { get; set; } = null!;
    public int PlayerId { get; set; }
    public Match Player { get; set; } = null!;

    public  ICollection<MatchEvent>? MatchEvents { get; set; }


}