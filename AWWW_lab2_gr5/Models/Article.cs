public class Article
{
    public int Id {get; set;}
    public string? Title {get; set;}
    public string? Lead {get; set;}
    public string? Content {get; set;}
    public DateTime CreationDate {get; set;}
    public virtual Author Author {get; set;}
    public virtual Category Category {get; set;}
    public virtual Match? Match {get; set;}
    public virtual IList<Comment> Comments {get; set;}
    public virtual IList<Tag> Tags {get; set;}
}