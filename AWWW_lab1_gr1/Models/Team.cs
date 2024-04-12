namespace AWWW_lab1_gr1.Models;
public class Team {
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Country { get; set; }

    public required string City { get; set; }
    public  int LeagueId { get; set; }
    public required DateTime FoundingDate { get; set; } 

    public List<Player>? Players { get; set; }

    public required League? League { get; set; }

    public required List<Match>? HomeMatches {get;set;}

    public required List<Match>? AwayMatches {get;set;}
}