using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;

namespace AWWW_lab1_gr2.Controllers
{
    public class ArticleController : Controller {
        private readonly DatabaseContext asd;
        public ArticleController(DatabaseContext databaseContext){
            asd = databaseContext;
        }
        public IActionResult Index(){
            return View(asd.Articles.ToList()!);
        }
        public IActionResult Dodaj(int id = -1)
        {

            if (id != -1)
            {
                var article = asd.Articles!
                    .FirstOrDefault(a => a.Id == id);
                @ViewBag.Header = "Edytuj artykuł";
                @ViewBag.ButtonText = "Edytuj";
                return View(article);
            }
            else
            {
                @ViewBag.Header = "Dodaj artykuł";
                @ViewBag.ButtonText = "Dodaj";
                return View();
            }
            
        }

        [HttpPost]
        public IActionResult Dodaj(Article article)
        {
            if (article.Id != 0)
            {
                var a = asd.Articles!.FirstOrDefault(a => a.Id == article.Id);
                if (a != null)
                {
                    a.Author = article.Author;
                    a.Category = article.Category;
                    a.Comments = article.Comments;
                    a.Content = article.Content;
                    a.CreationDate = article.CreationDate;
                }
            }
            else
            {
                asd.Articles!.Add(article);
            }
            asd.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}