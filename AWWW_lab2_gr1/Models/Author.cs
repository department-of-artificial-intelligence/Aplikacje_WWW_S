namespace AWWW_lab2_gr1.Models;
public class Author
{
  public int Id { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }

  public ICollection<Article> Articles { get; set; }
}