namespace AWWW_lab1_gr1.Models;
using Microsoft.EntityFrameworkCore;
public class Comment{
    public int ID{get; set;}
    public required string Title{get;set;}
    public required string Content{get;set;}
}