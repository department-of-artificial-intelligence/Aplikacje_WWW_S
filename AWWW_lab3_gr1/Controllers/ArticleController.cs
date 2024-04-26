using AWWW_lab3_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab3_gr1.Controllers;

public class ArticleController : Controller
{
  private readonly MyDbContext _dbContext;

  public ArticleController(MyDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public ActionResult Index()
  {
    ViewBag.Title = "Articles";
    List<Article> articles = _dbContext.Articles
      .Include(el => el.Author)
      .Include(el => el.Tags)
      .ToList();
    return View(articles);
  }

  private List<Tag> GetTags()
  {
    return _dbContext.Tags.ToList();
  }

  private List<Category> GetCategories()
  {
    return _dbContext.Categories.ToList();
  }

  private List<Author> GetAuthors()
  {
    return _dbContext.Authors.ToList();
  }

  private List<Match> GetMatches()
  {
    return _dbContext.Matches
        .Include(el => el.AwayTeam)
        .Include(el => el.HomeTeam)
        .ToList();
  }

  public IActionResult Add()
  {
    ViewBag.Tags = GetTags();
    ViewBag.Categories = GetCategories();
    ViewBag.Authors = GetAuthors();
    ViewBag.Matches = GetMatches();
    return View("Edit", new Article());
  }

  public IActionResult Edit(int id)
  {
    Article article = _dbContext.Articles.FirstOrDefault(el => el.Id == id);

    if (article == null)
    {
      return View("Error");
    }

    ViewBag.Tags = GetTags();
    ViewBag.Categories = GetCategories();
    ViewBag.Authors = GetAuthors();
    ViewBag.Matches = GetMatches();

    return View("Edit", article);
  }

  [HttpPost]
  public IActionResult Save(Article article, int[] ArticleTags)
  {
    int b = 10;
    var tags = _dbContext.Tags.Where(el => ArticleTags.Contains(el.Id)).ToList();
    int a = 0;


    foreach (var tag in tags)
    {
      Console.WriteLine(tag.Name);
    }

    article.Tags = tags;


    if (article.Id == 0)
    {
      // article.Tags = tags;
      _dbContext.Articles.Add(article);
    }
    else
    {

      _dbContext.Articles.Update(article);
      // _dbContext.SaveChanges();

      // _dbContext.Articles
      // .Include(el => el.Tags)
      // .FirstOrDefault(el => el.Id == article.Id)
      // .Tags.Clear();

      // Article articleDb = _dbContext.Articles.FirstOrDefault(p => p.Id == article.Id);
      // article.Tags = tags;
    }

    try
    {
      _dbContext.SaveChanges();
    }
    catch (Exception error)
    {
      View("Error");
    }

    return RedirectToAction("Details", "Article", new { id = article.Id });
  }

  public IActionResult Details(int id)
  {
    Article article = _dbContext.Articles
    .Include(el => el.Author)
    .Include(el => el.Category)
    .Include(el => el.Match)
    .Include(el => el.Comments)
    .Include(el => el.Tags)
    .FirstOrDefault(el => el.Id == id);


    if (article == null)
    {
      return RedirectToAction("Error");
    }

    return View(article);
  }

  public ActionResult Delete(int id)
  {
    Article article = _dbContext.Articles.Find(id);

    if (article == null)
    {
      return RedirectToAction("Index");
    }

    _dbContext.Articles.Remove(article);
    _dbContext.SaveChanges();

    return RedirectToAction("Index");
  }
}