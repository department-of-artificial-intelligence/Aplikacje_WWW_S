namespace AWWW_lab2_gr3.Models;

public class Team{
    public int Id { get; set;}
    public string Name { get; set;}
    public string Country { get; set;}
    public string City { get; set;}
    public DateTime FoundingDate{ get; set;}

    public int LeagueId { get; set; }
    public virtual League League { get; set; }

    public ICollection<Player> Player { get; set; }
    public ICollection<Match> Match { get; set; }
}