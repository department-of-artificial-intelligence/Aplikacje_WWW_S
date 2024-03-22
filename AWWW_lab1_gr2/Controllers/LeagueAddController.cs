using System;
using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Mvc;
public class LeagueAddController:Controller
{
    private readonly MyDbContext Context;
    public LeagueAddController(MyDbContext _context){
        Context = _context;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(League league)
    {
        if (ModelState.IsValid)
        {
            Context.Leagues.Add(league);
            Context.SaveChanges();
            return RedirectToAction("Index", "Leagues"); // Przekierowanie gdziekolwiek chcesz
        }
        return View(league);
    }
}