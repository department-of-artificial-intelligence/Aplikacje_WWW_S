namespace AWWW_lab1_gr1.Models;
public class Article {
    public int Id { get; set; }
    public required string Lead { get; set; }

    public  required string Title { get; set; }

    public required string Content { get; set; }

    public List<Comment>? Comments { get; set; }

    public required Author Author { get; set; }

    public  required Category Category { get; set; }

    public required List<Tag> Tags { get; set; }

    public required Match Match { get; set; }

    public DateTime CreationDate { get; set; }
}