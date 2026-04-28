namespace AWWW_lab1_gr1.Models;

public class Article
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    public DateTime CreationDate { get; set; }
}