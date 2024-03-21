namespace AWWW_lab1_gr1.Models;
public class Article {
    public int Id { get; set; }

    public int AuthorId {get;set;}

    public string Lead { get; set; }

    public  string Title { get; set; }

    public string Content { get; set; }

    public List<Comment>? Comments { get; set; }

    public  Author Author { get; set; }

    public  Category Category { get; set; }

    public List<Tag> Tags { get; set; }

    public Match Match { get; set; }

    public DateTime CreationDate { get; set; }
}