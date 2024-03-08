public class Tag{
    public int Id {get; set;}
    public string Name {get; set;} = null!;
    public List<Article> _articles = new List<Article>();
}