namespace AWWW_lab3_gr2.Models;
using System.Data;

public class MatchPlayer
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int MatchId { get; set; }
    public Match Match { get; set; } = null!;
    public int PlayerId { get; set; }
    public Player Player { get; set; } = null!;
    public int PositionId { get; set; }
    public Position Position { get; set; } = null!;
    public ICollection<MatchEvent> MatchEvents { get; set; }
}