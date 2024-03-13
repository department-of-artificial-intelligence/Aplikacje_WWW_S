using Microsoft.AspNetCore.Mvc;

public class ArticleController : Controller
{
    private List<Article> articles = new List<Article>
    {
            new Article {
                Id = 1,
                Title = "Artykuł 1",
                Content = "Lorem ipsum...",
                CreationDate = DateTime.Now
            },
            new Article {
                Id = 2,
                Title = "Artykuł 2",
                Content = "Lorem ipsum...",
                CreationDate = DateTime.Now
            },
            new Article {
                Id = 3,
                Title = "Artykuł 3",
                Content = "Lorem ipsum...",
                CreationDate = DateTime.Now
            }
        };
    public IActionResult Index() 
    {
        

        return View(articles);
    }

    public IActionResult Details(int id) {
        var art = articles.FirstOrDefault(a => a.Id == id);
        return View(art);
    }
}