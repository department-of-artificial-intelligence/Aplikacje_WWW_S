namespace AWWW_lab3_gr2.Models;
using System.Data;

public class League
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Country { get; set; }
    public int Level { get; set; }
    public ICollection<Team>? Teams { get; set; }
}