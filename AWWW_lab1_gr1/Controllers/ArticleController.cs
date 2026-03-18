using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;
using AWWW_lab1_gr1.Models;

namespace AWWW_lab1_gr1.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index(int id=1)
        {
            var article = new List<Article>
            {
            new Article{
                Id = 1,
                Title = "Artykuł 1",
                Content = "Przykładowy tekst",
                CreationDate = DateTime.Now
            }, 
            new Article{
                Id = 1,
                Title = "Artykuł 1",
                Content = "Przykładowy tekst",
                CreationDate = DateTime.Now
            }, 
            new Article{
                Id = 1,
                Title = "Artykuł 1",
                Content = "Przykładowy tekst",
                CreationDate = DateTime.Now
            }
        };
            return View(article);
    }
    }
}

//clone respository
//link github
//select repository
//nie pracowac na niczym jak jest master
//kliknac na master szukac siebie
//pojawiaja sie pliki
//jak commit to trzeba podac token czyli czerwony tekst z moodle
//SYNCH NA SAMYM POCZATKU ZAWSZE KLIKNAC i robic commit +++ push
//zmiany pojawia sie na githubie a jak nie to kółeczko wynchornize changes na dole vscode przyh nazwisku