using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;


public class MatchEventController:Controller{
    public IActionResult Index()
    {
        ViewBag.Title = "Wydarzenia";
        return View();
    }
}