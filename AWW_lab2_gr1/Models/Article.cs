namespace AWW_lab2_gr1.Models;

public class Article
{
  public int Id { get; set; }
  public string Title { get; set; }
  public string Lead { get; set; }
  public string Content { get; set; }
  public DateTime CreationDate { get; set; }

  public Author Author { get; set; }

  public Category Category { get; set; }

  public ICollection<Tag> Tags { get; set; }
  public Match? Match { get; set; }
  public ICollection<Comment> Comments { get; set; }
}