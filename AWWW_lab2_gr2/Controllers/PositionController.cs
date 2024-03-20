using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr2.Models;

public class PositionController : Controller{

    private readonly ApplicationDbContext _context;
		public PositionController(ApplicationDbContext context)
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
		public IActionResult Add(Position position)
		{
			_context.Positions.Add(position);
			_context.SaveChanges();
			return View("Added", position);
		}turn View(articles[id-1]);
        }
}