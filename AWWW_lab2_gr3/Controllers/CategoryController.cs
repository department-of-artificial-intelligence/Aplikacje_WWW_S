using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3.Controllers;
public class CategoryController : Controller{
        public IActionResult Index(int id=1){
        var categories = new List <Category>{
                new Category{
                Id = 1,
                Name = "x"
                },
                new Category{
                Id = 1,
                Name = "x2"
                },
                new Category{
                Id = 1,
                Name = "x3"
                }
        };
        return View(categories[id-1]);
        }
}