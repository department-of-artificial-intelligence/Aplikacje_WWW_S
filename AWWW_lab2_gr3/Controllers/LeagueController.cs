using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3.Controllers;
public class LeagueController : Controller{
        public IActionResult Index(int id=1){
        var leagues = new List <League>{
                new League{
                Id = 1,
                Name = "liga1",
                Country = "Polska",
                Level = 1,
                },
                new League{
                Id = 2,
                Name = "liga1",
                Country = "Niemcy",
                Level = 1,
                },
                new League{
                Id = 3,
                Name = "liga1",
                Country = "Francja",
                Level = 1,
                },
        };
        return View(leagues[id-1]);
        }
}