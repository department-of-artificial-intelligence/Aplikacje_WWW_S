using System.Globalization;
using Microsoft.Net.Http.Headers;
namespace AWWW_lab1_gr2.Models;
public class Author{
    public int Id;
    public string ?FirstName;
    public string ?LastName;
    public ICollection<Article> Articles {get; set;}=null!;
}