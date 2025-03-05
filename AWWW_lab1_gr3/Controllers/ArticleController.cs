using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class ArticleController : Controller{
        public IActionResult Index(){
        ViewBag.Title = "Article";
        return View();
        }
}
