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
        var tags = new List <Tag>{
                new Tag{
                Id = 1,
                Name = "t"
                },
                new Tag{
                Id = 1,
                Name = "t2"
                },
                new Tag{
                Id = 1,
                Name = "t3"
                }
        };
        return View(tags[id-1]);
        }
}