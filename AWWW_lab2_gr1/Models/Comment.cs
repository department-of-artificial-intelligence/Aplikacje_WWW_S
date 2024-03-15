namespace AWWW_lab2_gr1.Models;
public class Comment
{
  public int Id { get; set; }
  public string Title { get; set; }
  public string Content { get; set; }

  public Article Articles { get; set; }
}