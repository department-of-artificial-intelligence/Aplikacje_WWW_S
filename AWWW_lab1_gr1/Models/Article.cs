namespace AWWW_lab1_gr1.Models;
public class Article
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Lead { get;set;} = "";
    public string Content { get; set; } = "";
    public DateTime CreationDate { get; set; }

    // * - 1
    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;
    // * - 1
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    // 1 - *
    public ICollection<Comment>? Comments { get; set; }
    // * - *
    public ICollection<Tag>? Tags { get; set; }

    public required ICollection<Match> Matches {get; set;}

}