using System;
using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Mvc;
public class TeamAddController:Controller
{
    private readonly MyDbContext Context;
    public TeamAddController(MyDbContext _context){
        Context = _context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Team team)
    {
        if (ModelState.IsValid)
        {
            Context.Teams.Add(team);
            Context.SaveChanges();
            return RedirectToAction("Index", "Teams");
        }
        return View(team);
    }
}