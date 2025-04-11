using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3.Controllers{

    public class CategoryController : Controller
    {

        private readonly AppDbContext _dbcontext;

        public CategoryController(AppDbContext db)
        {
            _dbcontext = db;
        }

        
    public IActionResult Index()
    {
        ViewBag.Title = "Kategorie";
        return View();
    }

    
    }


}