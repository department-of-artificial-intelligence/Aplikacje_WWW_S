using AWWW_lab1_gr1.Data;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab1_gr1.Controllers
{
    public class ArticleController : Controller
    {
        private readonly MyDBContext _dbContext;

        public ArticleController(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Article> articles = _dbContext.Articles!.ToList();
            return View(articles);
        }

        public IActionResult Details(int id)
        {
            Article? article = _dbContext.Articles
                .Include(a => a.Author)
                .FirstOrDefault(x => x.Id == id);
            return View(article);
        }

        public IActionResult Add()
        {
            var authors = _dbContext.Authors.Select(a => new
            {
                Id = a.Id,
                FullName = $"{a.FirstName ?? ""} {a.LastName ?? ""}"
            }).ToList();

            ViewData["AuthorId"] = new SelectList(authors, "Id", "FullName");
            ViewData["CategoryId"] = new SelectList(_dbContext.Categories, "Id", "Id");
            ViewData["MatchId"] = new SelectList(_dbContext.Matches, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Article article)
        {
            article.CreationDate = DateTime.Now;
            article.Author = _dbContext.Authors.Find(article.AuthorId);


            //if (ModelState.IsValid)
            //{
            _dbContext.Articles!.Add(article);
            _dbContext.SaveChanges();
            //}

            //var authors = _dbContext.Authors.Select(a => new
            //{
            //    Id = a.Id,
            //    FullName = $"{a.FirstName ?? ""} {a.LastName ?? ""}"
            //}).ToList();

            ViewData["AuthorId"] = _dbContext.Authors.Select(a => new SelectListItem() { Text = $"{a.FirstName ?? ""} {a.LastName ?? ""}", Value = a.Id.ToString() });
            //ViewData["AuthorId"] = new SelectList(authors, "Id", "FullName", article.AuthorId);
            ViewData["CategoryId"] = new SelectList(_dbContext.Categories, "Id", "Id", article.CategoryId);
            ViewData["MatchId"] = new SelectList(_dbContext.Matches, "Id", "Id", article.MatchId);
            return RedirectToAction("Index");
        }
    }
}
