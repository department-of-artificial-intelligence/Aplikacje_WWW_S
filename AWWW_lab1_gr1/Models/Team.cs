namespace AWWW_lab1_gr1.Models;
public class Team{
    public int ID{get; set;}
    public required string Name{get;set;}
    public required string Country{get;set;}
    public required string City{get;set;}
    public DateTime FoundingDate{get;set;}

    public virtual ICollection<Match>? HomeMatches{get;set;}
    public virtual ICollection<Match>? AwayMatches{get;set;}

    public List<Player>? Players{get;set;}
    public required League League { get; set; }
}