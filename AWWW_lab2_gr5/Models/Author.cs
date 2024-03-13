public class Author
{
    public int Id {get; set;}
    public string? FirstName {get; set;}
    public string? LastName {get; set;}
    public virtual List<Article> Articles {get; set;}
}