namespace AWWW_lab1_gr1.Models;
using Microsoft.EntityFrameworkCore;
public class Author{
    public required int ID{get; set;}
    public required string FirstName{get; set;}
    public required string LastName{get; set;}

    public ICollection<Article>? Articles { get; set; }
}