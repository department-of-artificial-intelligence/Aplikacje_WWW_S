using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;


public class LeagueController:Controller{
    public IActionResult Index()
    {
        ViewBag.Title = "Ligi";
        return View();
    }
}