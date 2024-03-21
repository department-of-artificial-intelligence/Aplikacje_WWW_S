namespace AWWW_lab1_gr2.Models;
public class Team{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public DateTime FoundingDate { get; set; }
    public ICollection<Player> Players {get; set;}=null!;
    public ICollection<Match> AwayMatches {get; set;}=null!;
    public ICollection<Match> HomeMatches {get; set;}=null!;
    public int LeagueId {get; set;}
    public League League {get; set;}=null!;
}