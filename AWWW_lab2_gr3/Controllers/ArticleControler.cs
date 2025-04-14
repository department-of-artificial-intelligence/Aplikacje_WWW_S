using AWWW_lab2_gr3.Models;
using Microsoft.AspNetCore.Mvc;

public class ArticleController : Controller
{
    private readonly OskiDBContext _dbContext;

    public ArticleController(OskiDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var Articles = _dbContext.Article.ToList();
        return View(Articles);
    }

}