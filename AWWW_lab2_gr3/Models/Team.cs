namespace AWWW_lab2_gr3.Models;

public class Team
{
    public int Id {get; set;}
    public string Name {get; set;}
    public string Country {get; set;}
    public string City {get; set;}
    public DateTime FoundingDate {get; set;}

    public List<Match> Matches {get; set;}
    
    public int LeageId {get; set;}
    public Leage League {get ;set}

    public List<Player> Players {get; set;}
}