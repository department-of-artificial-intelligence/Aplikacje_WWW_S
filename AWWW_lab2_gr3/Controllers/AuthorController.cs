using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3.Controllers {
    public class AuthorController : Controller {

        private readonly MyDbContext _dbContext;

        public AuthorController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index() {
            return View();
        }

        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        public IActionResult Add(Author author)
        {
            if (ModelState.IsValid)
            {
                if (author == null) //można wykonać takie sprawdzenie, w razie braku - błąd na etapie "SaveChanges"
                {
                    return View("Error");

                }
                _dbContext.Author.Add(author);

                try
                {
                    _dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    return View("Error");
                }

                return View();
            }
            return View("Error");
        }
    }
}
