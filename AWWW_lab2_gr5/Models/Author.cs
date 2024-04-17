public class Author
{
    public int Id {get; set;}
    public string? FirstName {get; set;}
    public string? LastName {get; set;}
    public virtual IList<Article> Articles {get; set;}
}