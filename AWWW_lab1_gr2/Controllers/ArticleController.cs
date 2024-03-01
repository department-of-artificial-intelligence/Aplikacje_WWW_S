using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;

public class ArticleController : Controller{
    public IActionResult Index(){
        var articles = new List<Article>{
            new Article{
                Id=1,
                Title="Artykuł 1",
                Content="Lorem ipsum...",
                CreationDate=DateTime.Now
            },
            
        };

        return View(articles[id-1]);
    }
}