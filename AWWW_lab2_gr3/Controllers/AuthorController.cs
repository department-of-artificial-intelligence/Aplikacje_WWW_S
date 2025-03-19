using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3.Controllers;
public class AuthorController : Controller{
        public IActionResult Index(int id=1){
        var authors = new List <Author>{
                new Author{
                Id = 1,
                FirstName = "Kamil",
                LastName = "Garus",
                },
                new Author{
                Id = 2,
                FirstName = "Jan",
                LastName = "Nowak",
                },
                new Author{
                Id = 3,
                FirstName = "Piotr",
                LastName = "Kowalski",
                }
        };
        return View(authors[id-1]);
        }
}