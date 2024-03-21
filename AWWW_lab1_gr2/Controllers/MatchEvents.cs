using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;

public class MatchEventsController:Controller{
    public IActionResult Index(){
        ViewBag.Title = "Lista zdarzeń";
        return View();
    }
}