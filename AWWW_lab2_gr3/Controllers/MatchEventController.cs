using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3.Controllers{

    public class MatchEventController : Controller
    {

        private readonly AppDbContext _dbcontext;

        public MatchEventController(AppDbContext db)
        {
            _dbcontext = db;
        }
    
    
    
        public IActionResult Index()
        {
        
            ViewBag.Title = "Wydarzenia meczowe";
            return View();
        }
    
    }


}