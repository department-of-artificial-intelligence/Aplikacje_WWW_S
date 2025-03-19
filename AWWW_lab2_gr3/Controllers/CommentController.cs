using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3.Controllers;
public class CommentController : Controller{
        public IActionResult Index(int id=1){
        var comments = new List <Comment>{
                new Comment{
                Id = 1,
                Title = "title 1",
                Content = "content 1",
                },
                new Comment{
                Id = 2,
                Title = "title 2",
                Content = "content 2",
                },
                new Comment{
                Id = 3,
                Title = "title 3",
                Content = "content 3"
                },
        };
        return View(comments[id-1]);
        }
}