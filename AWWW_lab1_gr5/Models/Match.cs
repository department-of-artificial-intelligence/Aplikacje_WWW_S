namespace AWWW_lab1_gr5.Models;
public class Match{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string ?Stadium { get; set; }
    public ICollection<Article> Articles {get; set;}=null!;
    public int HomeTeamId {get; set;}
    public Team HomeTeam {get; set;}=null!;
    public int AwayTeamId {get; set;}
    public Team AwayTeam {get; set;}=null!;
    public ICollection<MatchPlayer> MatchPlayers {get; set;}=null!;
    public ICollection<MatchEvent> MatchEvents {get; set;}=null!;
    


}