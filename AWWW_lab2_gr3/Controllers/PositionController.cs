using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3.Controllers{

    public class PositionController : Controller
    {

        private readonly AppDbContext _dbContext;

        public PositionController(AppDbContext db)
        {
            _dbContext = db;
        }


        
        public IActionResult Index()
        {
            ViewBag.Title = "Pozycje";
            return View();
        }

    }


}