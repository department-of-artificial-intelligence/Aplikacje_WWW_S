using AWWW_lab2_gr2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab2_gr2.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ArticleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var articles = _context.Articles
                .Include(a => a.Author)
                .Include(a => a.Category)
                .Include(a => a.Tags)
                .ToList();
            return View(articles);
        }

        public IActionResult Add()
        {
            var authors = _context.Authors.ToList();
            var authorsList = new List<SelectListItem>();
            foreach (var a in authors)
            {
                string text = a.FirstName;
                string id = a.Id.ToString();
                authorsList.Add(new SelectListItem(text, id));
            }
            ViewBag.authorsList = authorsList;

            var categories = _context.Categories.ToList();
            var categoriesList = new List<SelectListItem>();
            foreach (var a in categories)
            {
                string text = a.Name;
                string id = a.Id.ToString();
                categoriesList.Add(new SelectListItem(text, id));
            }
            ViewBag.categoriesList = categoriesList;

            var tags = _context.Tags.ToList();
            var tagsList = new List<SelectListItem>();
            foreach (var a in tags)
            {
                string text = a.Name;
                string id = a.Id.ToString();
                tagsList.Add(new SelectListItem(text, id));
            }
            ViewBag.tagsList = tagsList;

            return View();
        }

        [HttpPost]
        public IActionResult Add(Article article, List<int> tags)
        {
            var author = _context.Authors.FirstOrDefault(a => a.Id == article.AuthorId);
            if (author == null)
            {
                return View("Error");
            }
            article.Author = author;

            var category = _context.Categories.FirstOrDefault(a => a.Id == article.CategoryId);
            if (category == null)
            {
                return View("Error");
            }
            article.Category = category;

            var articleTags = _context.Tags.Where(t => tags.Contains(t.Id)).ToList();
            article.Tags = articleTags;

            _context.Articles.Add(article);
            _context.SaveChanges();
            return View("Added", article);
        }
    }
}
