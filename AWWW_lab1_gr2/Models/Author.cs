using System.Globalization;
using Microsoft.Net.Http.Headers;
namespace AWWW_lab1_gr2.Models;
public class Author{
    public int Id { get; set; }
    public string ?FirstName { get; set; }
    public string ?LastName { get; set; }
    public ICollection<Article> Articles {get; set;}=null!;
}