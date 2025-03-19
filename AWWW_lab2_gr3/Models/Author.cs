namespace AWWWW_lab2_gr3.Models;

using System.Data;
using Microsoft.AspNetCore.Mvc;

public class Author
{
    public int Id { get; set;}
    public string FirstName { get; set;}
    public string LastName{ get; set;}

    public List<Article> Articles { get; set;}
}
