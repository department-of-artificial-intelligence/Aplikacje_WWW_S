using AWWW_lab1_gr5.Models;
public IActionResult Index(int id=1)
{
    var article = new List<Article>
    {
        new Article{
        Id = 1,
        Title = "Artykuł 1",
        Content = "Lorem ipsumm..."
        CreationDate = DateTime.Now
        },
         new Article{
        Id = 2,
        Title = "Artykuł 2",
        Content = "Lorem ipsumm..."
        CreationDate = DateTime.Now
        },
         new Article{
        Id = 3,
        Title = "Artykuł 3",
        Content = "Lorem ipsumm..."
        CreationDate = DateTime.Now
        }
    };

    return View(articles[id-1]);
}