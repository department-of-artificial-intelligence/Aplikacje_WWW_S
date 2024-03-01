using Microsoft.AspNetCore.Mvc;


public class ArticleController : Controller
{
    public IActionResult Index(int id = 1)
    {
        
        var articles = new List<Article>
        {
            new Article { Id = 1, Title = "First article", Content = "Content of the first article", CreationDate = DateTime.Now },
            new Article { Id = 2, Title = "Second article", Content = "Content of the second article", CreationDate = DateTime.Now },
            new Article { Id = 3, Title = "Third article", Content = "Content of the third article", CreationDate = DateTime.Now }
        };

        return View(articles[id-1]);
    }
}
