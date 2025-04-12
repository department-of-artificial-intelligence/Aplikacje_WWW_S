using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3.Controllers{

    public class TagController : Controller
    {

        private readonly AppDbContext _dbContext;

        public TagController(AppDbContext db)
        {
            _dbContext = db;
        }
    
            
        public IActionResult Index()
        {
            ViewBag.Title = "Tagi";
            var tags = _dbContext.Tags.ToList();
            return View("Index",tags);
        }
    
        [HttpGet]
        public IActionResult Add()
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
        public IActionResult Add(Tag tag, List<int> ArticleIds)
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


    }


}