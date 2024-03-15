namespace AWWW_lab1_gr1.Models;
public class MatchPlayer
{
    public int MatchId { get; set; }
    public virtual Match Match { get; set; }
    public int PlayerId { get; set; }
    public virtual Player Player { get; set; }
    public string Position { get; set; }
}