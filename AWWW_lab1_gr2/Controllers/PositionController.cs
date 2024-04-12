using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;


public class PositionController:Controller{
    public IActionResult Index()
    {
        ViewBag.Title = "Pozycje";
        return View();
    }
}