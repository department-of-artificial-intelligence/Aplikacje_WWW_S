namespace AWWW_lab2_gr3.Controllers;
using AWWW_lab2_gr3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class ArticleController : Controller
{
    private readonly MyDbContext _dbContext;

    public ArticleController(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var articles = _dbContext.Articles
                                        .Include(a => a.Tags)
                                        .Include(a => a.Author)
                                        .Include(a => a.Category)
                                        .Include(a => a.Match)
                                        .ToList();
        return View(articles);
    }
    public IActionResult Add()
    {
        ViewBag.TagsList = _dbContext.Tags.Select(a => new SelectListItem(a.Name, a.Id.ToString())).ToList();
        ViewBag.AuthorList = _dbContext.Authors.Select(a => new SelectListItem(a.FirstName + " " + a.LastName, a.Id.ToString())).ToList();
        ViewBag.CategoryList = _dbContext.Categories.Select(a => new SelectListItem(a.Name, a.Id.ToString())).ToList();
        ViewBag.MatchList = _dbContext.Matches.Select(a => new SelectListItem(a.HomeTeam.Name + " vs " + a.AwayTeam.Name, a.Id.ToString())).ToList();
        return View();
    }

    [HttpPost]
    public IActionResult Add(Article article , List<int> tags)
    {
        var articleTags = tags != null ? _dbContext.Tags.Where(t => tags.Contains(t.Id)).ToList() : new List<Tag>();

        var authors = _dbContext.Authors.FirstOrDefault(a => a.Id == article.AuthorId);
        article.Author = authors;
        var category = _dbContext.Categories.FirstOrDefault(a => a.Id == article.CategoryId);
        article.Category = category;
        var match = _dbContext.Matches.FirstOrDefault(a => a.Id == article.MatchId);

        _dbContext.Articles.Add(article);
        _dbContext.SaveChanges();
        return View("Added", article);
    }

    public IActionResult Edit(int id)
    {
        var article = _dbContext.Articles.FirstOrDefault(p => p.Id == id);
        if (article == null)
        {
            return NotFound();
        }
        ViewBag.TagsList = _dbContext.Tags
            .Select(t => new SelectListItem(t.Name, t.Id.ToString()))
            .ToList();
        return View(article);
    }

    [HttpPost]

    public IActionResult Edit(Article article, List<int> tags)
    {
        var existingarticles = _dbContext.Articles
                                  .Include(a => a.Tags)
                                  .Include(a => a.Author)
                                  .Include(a => a.Category)
                                  .Include(a => a.Match)
                                  .FirstOrDefault(a => a.Id == article.Id);

        if(existingarticles != null)
        {
            existingarticles.Title = article.Title;
            existingarticles.Lead = article.Lead;
            existingarticles.Content = article.Content;
            existingarticles.CreationDate = article.CreationDate;
            existingarticles.AuthorId = article.AuthorId;
            existingarticles.CategoryId = article.CategoryId;
            existingarticles.Tags = _dbContext.Tags.Where(t => tags.Contains(t.Id)).ToList();
            existingarticles.MatchId = article.MatchId;

            _dbContext.Articles.Update(existingarticles);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }


        return NotFound();
    }

    public IActionResult Delete(int id)
    {
        var article = _dbContext.Articles.FirstOrDefault(p => p.Id == id);
        if (article == null)
        {
            return NotFound();
        }
        _dbContext.Articles.Remove(article);
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }
}

