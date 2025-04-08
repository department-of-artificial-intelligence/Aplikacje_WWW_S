using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3.Controllers {
    public class MatchEventController : Controller {

        private readonly MyDbContext _dbContext;

        public MatchEventController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index() {
            return View();
        }
    }
}
