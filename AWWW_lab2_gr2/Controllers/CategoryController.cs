using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using AWWW_lab2_gr2.Models;
using AWWW_lab2_gr2.Data;
namespace AWWW_lab2_gr2.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CategoryController(AppDbContext dbContext){ _dbContext = dbContext;}

        public IActionResult Index(){
            return View(_dbContext.Categories.ToList());
        }

        public IActionResult Add(int id = -1){
            if(id != -1){
                var category = _dbContext.Categories!.FirstOrDefault(a=>a.Id == id);
                return View(category);
            }
            else{
                return View();
            }
        }


        [HttpPost]
        public IActionResult Add(Category category){
            if(category.Id != 0){
                var newInstance = _dbContext.Categories!.FirstOrDefault(newInstance => newInstance.Id == category.Id);
                if(newInstance != null){
                    newInstance.Name = category.Name;
                }
            }
            else{
                _dbContext.Categories!.Add(category);
            }
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}