namespace AWWW_lab1_gr1.Models;
public class Position{
    public int ID{get; set;}
    public required string Name{get;set;}
    public List<Player>? Players { get; set; }

    public List<MatchPlayer>? MatchPlayers { get; set; }
}