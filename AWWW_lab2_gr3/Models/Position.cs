namespace AWWW_lab2_gr3.Models;

public class Position
{
    public int Id {get; set;}
    public string Name {get; set;}

    public List<MatchPlayer> MatchPlayers {get; set;}

    public List<Player> Players {get; set;}
}