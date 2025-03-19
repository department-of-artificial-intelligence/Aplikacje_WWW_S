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
        var matches = new List <Match>{
                new Match{
                Id = 1,
                Date = DateTime.Now
                Stadium = "stadion 1"
                },
                new Match{
                Id = 2,
                Date = DateTime.Now,
                Stadium = "stadion 1"
                },
                new Match{
                Id = 3,
                Date = DateTime.Now,
                Stadium = "stadion 1"
                }
        };
        return View(matches[id-1]);
        }
}