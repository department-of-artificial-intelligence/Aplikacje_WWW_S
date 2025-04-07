namespace AWWW_lab02_gr3.Models;

public class Player
{
    public int Id {get; set;}
    public string FristName {get; set;}
    public string LastName {get; set}
    public string Country {get; set;}
    public DateTime BirthDate {get; set;}

    public List<MatchPlayer> MatchPlayers {get; set;}

    public List<Position> Positions {get; set;}

    public int TeamId {get; set;}
    public Team Team {get; set;}
}