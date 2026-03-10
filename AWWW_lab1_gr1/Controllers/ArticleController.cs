using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;

namespace AWWW_lab1_gr1.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index(int id = 1)
        {
            var articles = new List<Article>
            {
                //Id = 1,
                //Title = "Artykuł 1",
                //Content = "Przykładowy tekst",
                //CreationDate = DateTime.Now

                new Article{
                    Id = 1,
                    Title = "Artykuł 1",
                    Content = "Tekst do 1",
                    CreationDate = DateTime.Now
                },
                new Article{
                    Id = 2,
                    Title = "Artykuł 2",
                    Content = "Tekst do 2",
                    CreationDate = DateTime.Now
                },
                new Article{
                    Id = 3,
                    Title = "Artykuł 3",
                    Content = "Tekst do 3",
                    CreationDate = DateTime.Now
                }
            };
            return View(articles[id - 1]);
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