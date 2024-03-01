using Microsoft.AspNetCore.Mvc;

public class ArticleController:Controller{
    public IActionResult Index()
        {
            var article = new Article{
                Id = 1,
                Title = "Artykuł 1",
                Content = "Lorem ipsum",
                CreationDate = DateTime.Now
            };
            
            return View(article);
        }
}