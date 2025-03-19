namespace AWWWW_lab2_gr3.Models;

using System.Data;
using Microsoft.AspNetCore.Mvc;

public class Comment
{
    public int Id { get; set;}
    public string Title { get; set;}
    public string Content { get; set;}

    public int ArticleId { get; set;}
    public Article Article { get; set;}
}
