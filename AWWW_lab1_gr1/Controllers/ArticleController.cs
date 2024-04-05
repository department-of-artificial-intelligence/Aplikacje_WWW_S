using Microsoft.AspNetCore.Mvc;
using AWW_lab1_gr1.Models;

public class ArticleController : Controller
{
  public IActionResult Index(int id = 1)
  {
    Console.Write("dasdasd");

    var articles = new List<Article> {
      new Article(1, "Artykuł 1", "Lorem Ipsum", DateTime.Now),
      new Article(2, "Artykuł 2", "Lorem Ipsum", DateTime.Now),
      new Article(3, "Artykuł 3", "Lorem Ipsum", DateTime.Now),
   };

    return View(articles[id - 1]);
  }
}