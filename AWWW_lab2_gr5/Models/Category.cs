public class Category 
{
    public int Id {get; set;}
    public string? Name {get; set;}
    public virtual IList<Article> Articles {get; set;}
}