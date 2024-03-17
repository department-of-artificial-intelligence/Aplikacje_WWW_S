using AWWW_lab1_gr1.Models;

public class Article {
    public int Id {get; set;}
    public string Title { get; set; } = null!;
    public string Lead { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime CreationDate { get; set; }
    public Author Author { get; set; } = null!;
    public Category Category { get; set; } = null!;
    public List<Tag> Tags { get; set; } = null !;
    public List<Comment> Comments { get; set; } = null!;
    public Match? Match { get; set; }
}