namespace AWWW_lab02_gr3.Models;

public class Position
{
    public int Id {get; set;}
    public string Name {get; set;} = null!;

    public ICollection<MatchPlayer>? MatchPlayers {get; set;}

    public ICollection<Player>? Players {get; set;}
}