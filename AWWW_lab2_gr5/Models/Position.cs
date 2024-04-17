public class Position
{
    public int Id {get; set;}
    public string Name {get; set;}
    public virtual IList<MatchPlayer> MatchPlayers {get; set;}
}