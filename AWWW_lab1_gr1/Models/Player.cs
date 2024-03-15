namespace AWWW_lab1_gr1.Models;
public class Player
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual Team Team { get; set; }
    public virtual ICollection<MatchPlayer> MatchPlayers { get; set; }
}