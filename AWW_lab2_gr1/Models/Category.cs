namespace AWW_lab2_gr1.Models;

public class Category
{
  public int Id { get; set; }
  public string Name { get; set; }

  public ICollection<Article> Articles { get; set; }
}