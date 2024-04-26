namespace AWWW_lab3_gr1.Models;

public class Article
{
  public int Id { get; set; }
  public string Title { get; set; }
  public string Lead { get; set; }
  public string Content { get; set; }
  public DateTime CreationDate { get; set; }

  public Author Author { get; set; }
  public int AuthorId { get; set; }

  public Category Category { get; set; }
  public int CategoryId { get; set; }

  public ICollection<Tag> Tags { get; set; }
  public Match? Match { get; set; }
  public int? MatchId { get; set; }
  public ICollection<Comment> Comments { get; set; }
}