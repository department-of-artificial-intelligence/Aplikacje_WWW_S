using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr5.Models;

    public class LeadController : Controller
    {
        private readonly ApplicationDbContext _context;
		public LeagueController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(League league)
		{
			_context.Leagues.Add(league);
			_context.SaveChanges();
			return View("Added", league);
		}
    }
