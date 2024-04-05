using AWWW_lab1_gr1.Data;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab1_gr1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly MyDBContext _dbContext;
        public CategoryController(MyDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<IActionResult> Index()
        {
            using var context = _dbContext;
            var result = await context.Categories.ToListAsync();
            return View(result);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            if (ModelState.IsValid)
            {
                using var context = _dbContext;
                context.Categories.Add(category);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }
            using var context = _dbContext;
            var result = await context.Categories.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    using var context = _dbContext;
                    context.Categories.Update(category);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }
            using var context = _dbContext;
            var result = await context.Categories.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using var context = _dbContext;
            var result = await context.Categories.FindAsync(id);
            if (result != null)
            {
                context.Categories.Remove(result);
            }
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
