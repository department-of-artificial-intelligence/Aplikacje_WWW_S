using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr1.Models;

public class OrderController : Controller
{
    private readonly AppDbContext _db;

    public OrderController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        return View(_db.Orders.ToList());
    }

    public IActionResult Details(int id)
    {
        Order? ord = _db.Orders.Find(id);

        if (ord != null)
        {
            return View("Details", ord);
        }
        return RedirectToAction("Index");
    }

    public IActionResult Update(int id)
    {
        Order? ord = _db.Orders.Find(id);

        if (ord != null)
        {
            ViewBag.stats = _db.OrderStatuses.ToList();
            return View("Update", ord);
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Save(Order ord)
    {
        Order order = _db.Orders.FirstOrDefault(o => o.Id == ord.Id);

        if (order == null)
        {
            RedirectToAction("Index");
        }

        order.OrderStatusId = ord.OrderStatusId;

        OrderStatusHistory hist = new OrderStatusHistory();

        hist.OrderId = order.Id;
        hist.OrderStatusId = order.OrderStatusId;
        hist.ChangedAt = DateTime.Now;

        _db.OrderStatusHistories.Add(hist);

        _db.SaveChanges();

        return RedirectToAction("Index");
    }
}