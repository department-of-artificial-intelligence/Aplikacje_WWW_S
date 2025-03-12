public class Article
{
    public int Id { get; set;}
    public string Title { get; set;}
    public string Lead { get; set;}
    public string Content { get; set;}
    public DateTime CreationDate { get; set;}

    public ICollection<Comment> Comments { get; set; }

    public virtual Author author{ get; set;}
    
    public virtual Category Category{ get; set; }

    public ICollection<Tag> Tags { get; set; }

    public Match ?Match{ get; set; }


}