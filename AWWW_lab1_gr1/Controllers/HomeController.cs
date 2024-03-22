using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;
using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
 public class HomeController:Controller{

    public IActionResult Index()
    {
        ViewBag.Title = "Home";
        return View();
    }
}