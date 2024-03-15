using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr2.Models;

public class TagController : Controller{

    public ITagResult Index(int id=1)
        {
            var tags = new List<Tag>{
                new Tag{
                    Id = 1,
                    Name = "Tag 1"
                },
                new Tag{
                    Id = 2,
                    Name = "Tag 2"
                },
                new Tag{
                    Id = 3,
                    Name = "Tag 3"
                }
            };
            
            return View(articles[id-1]);
        }
}