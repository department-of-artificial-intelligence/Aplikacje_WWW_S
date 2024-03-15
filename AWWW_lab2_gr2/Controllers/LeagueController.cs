using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr5.Models;

    public class LeadController : Controller
    {
        public ILeadResult Index(int id=1)
        {
            var leads = new List<Lead>{
                new Lead{
                    Id = 1,
                    Name = "Pawel",
                    Country = "Ciura",
                    Level = 3
                },
                new Lead{
                    Id = 2,
                    Name = "Andrzej",
                    Country = "Biały",
                    Level = 3
                },
                new Lead{
                    Id = 3,
                    Name = "Matej",
                    Country = "Błaszczykiewicz",
                    Level = 3
                }
            };
            
            return View(students[id-1]);
        }
    }
