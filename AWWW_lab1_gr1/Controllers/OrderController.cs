using AWWW_lab1_gr1.Data;
using AWWW_lab1_gr1.Models;
using AWWW_lab1_gr1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab1_gr1.Controllers;

public class OrderController : Controller
{
    private readonly CompanyDbContext _db;

    public OrderController(CompanyDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var orders = await _db.Orders
            .Include(o => o.Customer)
            .Include(o => o.OrderStatus)
            .Include(o => o.OrderItems)
            .AsNoTracking()
            .OrderByDescending(o => o.CreatedAt)
            .ToListAsync();

        return View(orders);
    }

    public async Task<IActionResult> Details(int id)
    {
        var order = await _db.Orders
            .Include(o => o.Customer)
            .Include(o => o.OrderStatus)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
            .Include(o => o.StatusHistory.OrderByDescending(h => h.ChangedAt))
                .ThenInclude(h => h.OrderStatus)
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == id);

        if (order is null)
        {
            return NotFound();
        }

        var vm = new OrderDetailsViewModel
        {
            Order = order,
            TotalAmount = order.OrderItems.Sum(i => i.UnitPrice * i.Quantity)
        };

        return View(vm);
    }

    public async Task<IActionResult> EditStatus(int id)
    {
        var order = await _db.Orders
            .Include(o => o.OrderStatus)
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == id);

        if (order is null)
        {
            return NotFound();
        }

        var statuses = await _db.OrderStatuses
            .OrderBy(s => s.Id)
            .ToListAsync();

        var vm = new OrderEditStatusViewModel
        {
            OrderId = order.Id,
            CurrentStatusName = order.OrderStatus.Name,
            SelectedStatusId = order.OrderStatusId,
            AvailableStatuses = statuses
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                })
                .ToList()
        };

        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditStatus(OrderEditStatusViewModel vm)
    {
        var order = await _db.Orders
            .Include(o => o.OrderStatus)
            .FirstOrDefaultAsync(o => o.Id == vm.OrderId);

        if (order is null)
        {
            return NotFound();
        }

        var statuses = await _db.OrderStatuses
            .OrderBy(s => s.Id)
            .ToListAsync();

        if (!statuses.Any(s => s.Id == vm.SelectedStatusId))
        {
            ModelState.AddModelError(nameof(vm.SelectedStatusId), "Wybrany status nie istnieje.");
        }

        if (!ModelState.IsValid)
        {
            vm.CurrentStatusName = order.OrderStatus.Name;
            vm.AvailableStatuses = statuses
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                })
                .ToList();

            return View(vm);
        }

        if (order.OrderStatusId != vm.SelectedStatusId)
        {
            order.OrderStatusId = vm.SelectedStatusId;
            _db.OrderStatusHistories.Add(new OrderStatusHistory
            {
                OrderId = order.Id,
                OrderStatusId = vm.SelectedStatusId,
                ChangedAt = DateTime.UtcNow
            });

            await _db.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Details), new { id = order.Id });
    }
}
