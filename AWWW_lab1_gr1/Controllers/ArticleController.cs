using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


public class ArticleController : Controller
{
    LabOneContext dbContext;

    public ArticleController(LabOneContext dbContext)
    {
        this.dbContext = dbContext;
    }


    public IActionResult Index()
    {

        var articles = dbContext.Articles.Include(e => e.Category).Include(e => e.Tags).Include(e => e.Author).ToList();

        return View(articles);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.Categories = await dbContext.Categories.ToListAsync();
        ViewBag.Tags = await dbContext.Tags.ToListAsync();
        ViewBag.Authors = await dbContext.Authors.ToListAsync();



        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Article article, int Category, List<int> Tags, int Author)
    {

        article.Tags = await dbContext.Tags.Where(t => Tags.Contains(t.Id)).ToListAsync();


        foreach (var modelState in ViewData.ModelState.Values)
        {
            foreach (var error in modelState.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
        }


        if (ModelState.IsValid)
        {
            dbContext.Add(article);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        ViewBag.Categories = await dbContext.Categories.ToListAsync();
        ViewBag.Tags = await dbContext.Tags.ToListAsync();
        ViewBag.Authors = await dbContext.Authors.ToListAsync();

        return View(article);
    }
}
