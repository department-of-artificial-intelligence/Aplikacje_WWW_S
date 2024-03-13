public class Team
{
    public int Id {get; set;}
    public string Name {get; set;} = null!;
    public string Country {get; set;}
    public string City {get; set;}
    public DateTime FoundingDate {get; set;}
    public virtual List<Match> Matches {get; set;}
}