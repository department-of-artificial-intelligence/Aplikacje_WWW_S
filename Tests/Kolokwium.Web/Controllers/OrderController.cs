using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoMapper;
using Microsoft.Extensions.Localization;
using Kolokwium.ViewModel.VM;
using Kolokwium.Services.Interfaces;
using Kolokwium.Services.ConcreteServices;
using Kolokwium.ViewModel.VM.Order;
using Kolokwium.Services.DTO.Order;
using Kolokwium.ViewModel.VM.Meal;
namespace Kolokwium.Web.Controllers
{
    public class OrderController : BaseController
    {

        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService,ILogger logger, IMapper mapper, IStringLocalizer localizer) 
            : base(logger, mapper, localizer)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var dtos = await _orderService.GetAllAsync();
            var vms = Mapper.Map<IEnumerable<OrderVm>>(dtos);

            return View(vms);
        }

        [HttpGet]

        public async Task<IActionResult> Create()
        {
            var meals = await _orderService.GetMealsAsync();
            ViewBag.Meals = Mapper.Map<List<MealVm>>(meals);
            return View(new CreateOrderVm());

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(CreateOrderVm vm)
        {
            if (!ModelState.IsValid)
            {
                var meals = await _orderService.GetMealsAsync();
                ViewBag.Meals = Mapper.Map<List<MealVm>>(meals);
                return View(vm);
            }
            var dto = Mapper.Map<CreateOrderDto>(vm);
            await _orderService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _orderService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}