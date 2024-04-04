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
    public class TagController : Controller
    {
        private readonly AppDbContext _dbContext;

        public TagController(AppDbContext dbContext){ _dbContext = dbContext;}

        public IActionResult Index(){
            return View(_dbContext.Tags.ToList());
        }

        public IActionResult Add(int id = -1){
            if(id != -1){
                var tag = _dbContext.Tags!.FirstOrDefault(a=>a.Id == id);
                return View(tag);
            }
            else{
                return View();
            }
        }


        [HttpPost]
        public IActionResult Add(Tag tag){
            if(tag.Id != 0){
                var newInstance = _dbContext.Tags!.FirstOrDefault(newInstance => newInstance.Id == tag.Id);
                if(newInstance != null){
                    newInstance.Name = tag.Name;
                }
            }
            else{
                _dbContext.Tags!.Add(tag);
            }
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}