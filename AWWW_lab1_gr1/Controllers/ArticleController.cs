using Microsoft.AspNetCore.Mvc;
public class ArticleController : Controller
{

    public IActionResult Index(int id = 1)
    {
        var articles = new List<Article>()
        {

        new Article
        {
            Id = 1,
            Title = "artykuł 1",
            Content = "lorem impsu",
            CreationDate = DateTime.Now
        },
        new Article
        {
            Id =2,
            Title = "Artykuł 2",
            Content = "lorem ",
            CreationDate = DateTime.Now
                    },
        new Article
        {
            Id =3,
            Title = "Artykuł 3",
            Content = "lorem ",
            CreationDate = DateTime.Now
        }
        };
        return View(articles[id - 1]);
    }
}