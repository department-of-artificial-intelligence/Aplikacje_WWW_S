namespace AWWWW_lab1_gr3.Models;

using System.Data;
using Microsoft.AspNetCore.Mvc;

public class Article
{
    public int Id { get; set;}
    public string Title { get; set;}
    public string Content { get; set;}
    public DateTime CreationDate { get; set;} 
}
