namespace AWWW_lab1_gr2.Models;
public class Position{
    public int Id { get; set; }
    public string ?Name { get; set; }
    public ICollection<Player> Players {get; set;}=null!;
    public ICollection<MatchPlayer> MatchPlayers {get; set;}=null!;

}