using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3.Controllers{

    public class MatchEventController : Controller
    {

        private readonly AppDbContext _dbContext;

        public MatchEventController(AppDbContext db)
        {
            _dbContext = db;
        }
    
    
    
        public IActionResult Index()
        {
        
            ViewBag.Title = "Wydarzenia meczowe";
            return View();
        }
    
    }


}