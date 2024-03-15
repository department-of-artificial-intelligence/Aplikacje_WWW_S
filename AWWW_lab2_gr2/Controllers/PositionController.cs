using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr2.Models;

public class PositionController : Controller{

    public IPositionResult Index(int id=1)
        {
            var Positions = new List<Position>{
                new Position{
                    Id = 1,
                    Name = "Position 1"
                },
                new Position{
                    Id = 2,
                    Name = "Position 2"
                },
                new Position{
                    Id = 3,
                    Name = "Position 3"
                }
            };
            
            return View(articles[id-1]);
        }
}