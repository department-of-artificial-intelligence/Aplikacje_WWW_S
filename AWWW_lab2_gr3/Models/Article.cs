namespace AWWW_lab2_gr3.Models;

public class Article{
    public int Id {get; set;}
    public string Title { get; set; } = null!;
    public string Lead { get; set; }
    public string Content { get; set; } = null!;
    public DateTime CreationDate {get; set;}
    
    public int AuthorId { get; set; }
    public virtual Author Author { get; set; }

    public ICollection<Comment> Comments { get; set; }
    public ICollection<Tag> Tags { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }

    public int ArticleId { get; set; }
    public virtual Match Match { get; set; }
}