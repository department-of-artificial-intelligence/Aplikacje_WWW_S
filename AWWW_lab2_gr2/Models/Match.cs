public class Match{
    public List<Article> _articles = new List<Article>();
    public int Id {get; set;}
    public DateTime Date {get; set;}
    public string Stadium {get; set;} = null!;
    public List<Team> _teams = new List<Team>(2);
}