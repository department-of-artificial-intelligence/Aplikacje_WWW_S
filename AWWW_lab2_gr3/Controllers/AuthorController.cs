using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3.Controllers{

    public class AuthorController : Controller
    {

    
        private readonly AppDbContext _dbcontext;

        public AuthorController(AppDbContext db)
        {
            _dbcontext = db;
        }

        public IActionResult Index()
        {
            ViewBag.Title="Autorzy";
            return View();
        }


    
    }
}


/*
[HttpGet]
        public IActionResult Create()
        {
            var newTag = new Tag();

            var articles = _dbContext.Articles.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Title
            }).ToList();

            ViewBag.Articles = articles;

            return View(newTag);
        }

        [HttpPost]
        public IActionResult Create(Tag tag, List<int> ArticleIds)
        {
            if (ModelState.IsValid)
            {
                var selectedArticles = _dbContext.Articles
                    .Where(a => ArticleIds.Contains(a.Id))
                    .ToList();
                tag.Articles = selectedArticles;
                try
                {
                    _dbContext.Tags.Add(tag);
                }
                catch (Exception e)
                {
                    throw new Exception("Nie udało się dodać tagu: " + e.Message);
                }
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                var selectedArticlesIds = tag.Articles.Select(a => a.Id).ToList();

                var articles = _dbContext.Articles.Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Title,
                    Selected = selectedArticlesIds.Contains(a.Id)
                });

                ViewBag.Articles = articles;
                return View(tag);
            }
        }
*/