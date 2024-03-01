using Microsoft.AspNetCore.Mvc;
public class ArticleController : Controller
{
    public IActionResult Index(int id = 1)
    {
        var articles = new List<Article>
        {
            new Article
            {
                Id = 1,
                Title = "Title 1",
                Content = "My content 1",
                CreationDate = DateTime.Now
            },
            new Article
            {
                Id = 2,
                Title = "Title 2",
                Content = "My content 2",
                CreationDate = DateTime.Now
            },
            new Article
            {
                Id = 3,
                Title = "Title 3",
                Content = "My content 3",
                CreationDate = DateTime.Now
            },
        };
        return View(articles[id - 1]);
    }
}