using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;

public class LeaguesController:Controller{
    public IActionResult Index(){
        ViewBag.Title = "Lista lig";
        return View();
    }
}