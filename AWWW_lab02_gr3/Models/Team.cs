namespace AWWW_lab02_gr3.Models;

public class Team
{
    public int Id {get; set;}
    public string Name {get; set;} = null!;
    public string Country {get; set;} = null!;
    public string City {get; set;} = null!;
    public DateTime FoundingDate {get; set;}

    public ICollection<Match>? Matches {get; set;}
    
    public int LeagueId {get; set;}
    public League? League {get ;set;}
    
    public ICollection<Player>? Players {get; set;}
}