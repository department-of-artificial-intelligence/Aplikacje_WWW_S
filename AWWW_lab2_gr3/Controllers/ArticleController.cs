namespace AWWW_lab2_gr3.Controllers;
using AWWW_lab2_gr3.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class ArticleController : Controller{
    private readonly MyDbContext _dbContext;

public ArticleController(MyDbContext dbContext){
    _dbContext = dbContext;
}

public IActionResult Index(){
    var articles = _dbContext.Articles
    .Include(x => x.Tags)
    .Include(x => x.Category)
    .Include(x => x.Author)
    .Include(x => x.Match)
    .ToList();
    return View(articles);
}

public IActionResult Add(){
    ViewBag.TagsList = _dbContext.Tags.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
    ViewBag.AuthorList = _dbContext.Authors.Select(x => new SelectListItem(x.FirstName + " " + x.LastName, x.Id.ToString())).ToList();
    ViewBag.Category = _dbContext.Categories.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
    ViewBag.Match = _dbContext.Matches.Select(x => new SelectListItem(x.HomeTeam.Name + " vs " + x.AwayTeam.Name, x.Id.ToString())).ToList();
    return View();
}

[HttpPost]
public IActionResult Add(Article article, List<int> tags){
    var articleTags = tags != null ? _dbContext.Tags.Where(t => tags.Contains(t.Id)).ToList() : new List<Tag>();

    var authors = _dbContext.Authors.Where()
}
}