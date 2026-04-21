using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MultiSelectListExample.DAL;
using MultiSelectListExample.Models;

namespace MultiSelectListExample.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;

        public ArticleController(ApplicationDbContext dbContext, ILogger logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                var articles = _dbContext.Articles.Include(t => t.Tags);
                return View(articles);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IActionResult Add()
        {
            try
            {
                ViewBag.Tags = _dbContext.Tags.Select(t => new SelectListItem(t.Name, t.Id.ToString()));
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Article article, List<int> selectedTagsIds)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                article.Tags = _dbContext.Tags.Where(t => selectedTagsIds.Contains(t.Id)).ToList();
                _dbContext.Articles.Add(article);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
