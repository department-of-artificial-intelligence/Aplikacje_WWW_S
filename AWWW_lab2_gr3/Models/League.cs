namespace AWWWW_lab2_gr3.Models;

using System.Data;
using Microsoft.AspNetCore.Mvc;

public class League
{
    public int Id { get; set;}
    public string Name { get; set;}
    public string Country { get; set;}
    public int Level { get; set;}
    public List<Team> Teams { get; set;}
    
}
