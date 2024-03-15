namespace AWWW_lab2_gr1.Models;
public class Category
{
  public int Id { get; set; }
  public string Name { get; set; }

  public ICollection<Category> Categories { get; set; }

}