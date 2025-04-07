using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3.Controllers{
public class ArticleController : Controller
{
    private readonly AppDbContext _dbcontext;
    public ArticleController(AppDbContext dbc)
    {
        _dbcontext = dbc;
    }
    public IActionResult Index(int id)
    {
        var articles = new List<Article>{
            new Article
            {
                id = 21;
            }
        };

        return View(articles[id-1]);
    }

}
}