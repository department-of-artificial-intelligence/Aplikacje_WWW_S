namespace AWWW_lab1_gr1.Models;
public class Match
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public virtual League League { get; set; }
    public virtual ICollection<MatchEvent> MatchEvents { get; set; }
}