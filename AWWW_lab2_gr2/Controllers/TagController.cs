using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr2.Models;

public class TagController : Controller{

    private readonly ApplicationDbContext _context;
		public TagController(ApplicationDbContext context)
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
		public IActionResult Add(Tag tag)
		{
			_context.Tags.Add(tag);
			_context.SaveChanges();
			return View("Added", tag);
}
}