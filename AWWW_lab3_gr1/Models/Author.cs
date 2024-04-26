using System.ComponentModel.DataAnnotations.Schema;
namespace AWWW_lab3_gr1.Models;

public class Author
{
  public int Id { get; set; }
  required public string FirstName { get; set; }
  required public string LastName { get; set; }

  public ICollection<Article> Articles { get; set; }
}