namespace AWWWW_lab2_gr3.Models;

using System.Data;
using Microsoft.AspNetCore.Mvc;

public class Category
{
    public int Id { get; set;}
    public string Name { get; set;}

    public List<Article> Articles { get; set;}
}
