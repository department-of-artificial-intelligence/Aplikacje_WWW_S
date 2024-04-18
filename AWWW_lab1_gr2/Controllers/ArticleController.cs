using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;
public class ArticleController:Controller{
    public IActionResult Index(int itemid=1)
    {

        var articles = new List<Article>
        {
            new Article{
                Id=1,
                Title = "Pierwszy artykul..",
                Content = "tresc_art1",
                CreationDate = DateTime.Now
            },
            new Article{
                Id=2,
                Title = "Art.2",
                Content = "tresc_art2",
                CreationDate = DateTime.Now
            },
            new Article{
                Id=3,
                Title = "Art.3",
                Content = "tresc_art3",
                CreationDate = DateTime.Now
            },
            new Article{
                Id=4,
                Title = "Art.4",
                Content = "tresc_art4",
                CreationDate = DateTime.Now
            },
        };
        return View(articles[itemid-1]);


    }
}