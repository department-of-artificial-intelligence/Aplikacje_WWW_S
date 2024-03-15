using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr5.Models;

    public class AuthorController : Controller
    {
        public IAutshorResult Index(int id=1)
        {
            var authors = new List<Author>{
                new Author{
                    Id = 1,
                    FirstName = "Pawel",
                    LastName = "Ciura"
                },
                new Author{
                    Id = 2,
                    FirstName = "Andrzej",
                    LastName = "Biały",
                },
                new Author{
                    Id = 3,
                    FirstName = "Matej",
                    LastName = "Błaszczykiewicz",
                }
            };
            
            return View(students[id-1]);
        }
    }
