namespace AWWW_lab3_gr2.Models;
using System.Data;

public class Tag
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Article>? Articles { get; set; }
}