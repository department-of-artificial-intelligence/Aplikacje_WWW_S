public class Player
{
    public int Id {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Country {get; set;}
    public DateTime BirthDate {get; set;}
    public virtual Team Team {get; set;}
    public virtual MatchPlayer MatchPlayer {get; set;}
    public virtual IList<Position> Positions {get; set;}
}