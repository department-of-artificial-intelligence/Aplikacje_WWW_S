namespace AWWW_lab02_gr3.Models;

public class Player
{
    public int Id {get; set;}
    public string FristName {get; set;} = null!;
    public string LastName {get; set;} = null!; 
    public string Country {get; set;} = null!;
    public DateTime BirthDate {get; set;}

    public ICollection<MatchPlayer>? MatchPlayers {get; set;}

    public ICollection<Position>? Positions {get; set;}

    public int TeamId {get; set;}
    public Team? Team {get; set;}
}