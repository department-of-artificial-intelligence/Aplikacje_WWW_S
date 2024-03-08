public class Comment{
    public int Id {get; set;}
    public string Title {get; set;} = null!;
    public string Constent {get; set;} = null!;
    public Article CommentedArticle {get; set;} = null!;
}