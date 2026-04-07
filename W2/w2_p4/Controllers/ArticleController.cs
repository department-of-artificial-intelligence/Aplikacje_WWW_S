using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using w2_p4.Models;

namespace w2_p4.Controllers
{
    public class ArticleController : Controller
    {
        private readonly MyDbContext _dbContext;

        public ArticleController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IActionResult ErrorView()
            => View("Error", new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });

        public IActionResult Index(int id)
        {
            var article = _dbContext.Articles.FirstOrDefault(a => a.Id == id); 
            //można użyć też Find - operuje zawsze na kluczu głównym,
            //sprawdza czy encja jest już w pamięci przed odpytaniem bazy
            return article is not null ? View(article) : ErrorView();
        }

        public IActionResult Add()
        {
            /* POBRANIE LISTY AUTORÓW */

            //var authors = _dbContext.Authors.ToList();
            //var authorsList = new List<SelectListItem>();
            //foreach (var a in authors)
            //{
            //    string text = a.FirstName + " " + a.LastName;
            //    string id = a.Id.ToString();
            //    authorsList.Add(new SelectListItem(text, id));
            //}
            //ViewBag.authorsList = authorsList;

            ViewBag.authorsList = _dbContext.Authors
                .Select(a => new SelectListItem($"{a.FirstName} {a.LastName}", a.Id.ToString()))
                .ToList();

            /* POBRANIE LISTY TAGÓW */

            //var tags = _dbContext.Tags.ToList();
            //var tagsList = new List<SelectListItem>();
            //foreach (var t in tags)
            //{
            //    string text = t.Name;
            //    string id = t.Id.ToString();
            //    tagsList.Add(new SelectListItem(text, id));
            //}
            //ViewBag.tagsList = tagsList;

            ViewBag.tagsList = _dbContext.Tags
                .Select(t => new SelectListItem(t.Name, t.Id.ToString()))
                .ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Add(Article article, List<int> tags)
        {
            if (!ModelState.IsValid)
                return ErrorView();

            article.CreationDate = DateTime.Now;

            /* PRZYPISANIE TAGÓW */

            //foreach (var tag in tags)
            //{
            //    var existingTag = _dbContext.Tags.FirstOrDefault(t => t.Id == tag);
            //    if (existingTag != null)
            //        article.Tags.Add(existingTag);
            //
            //}
            var articleTags = tags != null ? _dbContext.Tags.Where(t => tags.Contains(t.Id)).ToList() : new List<Tag>();
            article.Tags = articleTags;

            /* PRZYPISANIE AUTORA */
            var author = _dbContext.Authors.FirstOrDefault(a => a.Id == article.AuthorId);
            if (author == null) //można wykonać takie sprawdzenie, w razie braku - błąd na etapie "SaveChanges"
            {
                return ErrorView();
            }
            article.Author = author; //jeśli nie przypiszemy, dane zostaną poprawnie zapisianie w bazie, ale nie będzie pobrany Autor do tej encji
            
            /* DODANIE ARTYLUŁU */
            _dbContext.Articles.Add(article);

            try
            {
                /* ZAPIS ZMIAN DO BAZY */
                _dbContext.SaveChanges();
                return View("Added", article);
            }
            catch
            {
                return ErrorView();
            }

        }
    }
}
