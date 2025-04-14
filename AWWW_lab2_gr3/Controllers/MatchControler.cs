using AWWW_lab2_gr3.Models;
using Microsoft.AspNetCore.Mvc;

public class MatchController : Controller
{
    private readonly OskiDBContext _dbContext;

    public MatchController(OskiDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var matches = _dbContext.Match.ToList();
        return View(matches);
    }

}