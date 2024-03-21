using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;

public class PositionsController:Controller{
    public IActionResult Index(){
        ViewBag.Title = "Pozycje";
        return View();
    }
}