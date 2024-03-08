public class Article{
    public List<Comment> _comments = new List<Comment>();
    public List<Tag> _tags = new List<Tag>();
    public int Id {get; set;}
    public string Title {get; set;} = null!; 
    public string Lead {get; set;} = null!;
    public string Content {get; set;} = null!;
    public DateTime CreationDate {get; set;}
    public Author ArticleAuthor {get; set;} = null!;
    public Category ArticleCategory {get; set;} = null!;
    public Match? AboutMatch {get; set;}
}