public class Article
{
    public int Id { get; set;}
    public string Title { get; set;}
    public string Lead { get; set;}
    public string Content { get; set;}
    public DateTime CreationDate { get; set;}

    public ICollection<Comment> Comments { get; set; }

    public int AuthorId { get; set; }
    public virtual Author Author{ get; set;}
    
   public ICollection<Category> Categories { get; set; }

    public ICollection<Tag> Tags { get; set; }

    public int MatchId { get; set; }
    public virtual Match ?Match{ get; set; }


}