namespace AWWW_lab3_gr2.Models;
using System.Data;

public class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Article>? Articles { get; set; }
}