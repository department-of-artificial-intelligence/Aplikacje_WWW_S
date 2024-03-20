using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr2.Models;

public class EventTypeController : Controller{

    private readonly ApplicationDbContext _context;
		public EventTypeController(ApplicationDbContext context)
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
		public IActionResult Add(EventType eventType)
		{
			_context.EventTypes.Add(eventType);
			_context.SaveChanges();
			return View("Added", eventType);
		}
}