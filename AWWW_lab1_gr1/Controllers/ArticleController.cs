using AWWW_lab1_gr1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab1_gr1.Controllers
{
    public class ArticleController : Controller
    {
        private readonly MyDBContext _dbContext;
        public ArticleController(MyDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<IActionResult> Index()
        {
            using var context = _dbContext;
            var result = await context.Articles.ToListAsync();

            return View(result);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = await _dbContext.Articles.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }
    }
}
