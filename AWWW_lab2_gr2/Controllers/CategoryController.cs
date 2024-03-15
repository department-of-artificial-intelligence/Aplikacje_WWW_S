using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr2.Models;

public class CategoryController : Controller{

    public ICategoryResult Index(int id=1)
        {
            var categoryes = new List<Category>{
                new Category{
                    Id = 1,
                    Name = "Category 1"
                },
                new Category{
                    Id = 2,
                    Name = "Category 2"
                },
                new Category{
                    Id = 3,
                    Name = "Category 3"
                }
            };
            
            return View(articles[id-1]);
        }
}