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
    public class AuthorController : Controller
    {
        private readonly AppDbContext _dbContext;

        public AuthorController(AppDbContext dbContext){ _dbContext = dbContext;}

        public IActionResult Index(){
            return View(_dbContext.Authors.ToList());
        }

        public IActionResult Add(int id = -1){
            if(id != -1){
                var author = _dbContext.Authors!.FirstOrDefault(a=>a.Id == id);
                return View(author);
            }
            else{
                return View();
            }
        }


        [HttpPost]
        public IActionResult Add(Author author){
            if(author.Id != 0){
                var newInstance = _dbContext.Authors!.FirstOrDefault(newInstance => newInstance.Id == author.Id);
                if(newInstance != null){
                    newInstance.FirstName = author.FirstName;
                    newInstance.LastName = author.LastName;
                }
            }
            else{
                _dbContext.Authors!.Add(author);
            }
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}