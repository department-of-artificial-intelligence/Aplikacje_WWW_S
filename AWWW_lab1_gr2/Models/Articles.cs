using System.Net.Mime;
namespace AWWW_lab1_gr2.Models;

public class Article
{
    public int Id { get; set; }
    public string? Title { get; set; } // Використання "?" для допуску null
    public string? Content { get; set; } // Використання "?" для допуску null
    public DateTime CreationDate { get; set; }
}
