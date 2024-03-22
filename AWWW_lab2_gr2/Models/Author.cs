using System.Globalization;
using Microsoft.Net.Http.Headers;
namespace AWWW_lab2_gr2.Models;
using System.Data;

public class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public ICollection<Article> Articles { get; set; } = null!;
}