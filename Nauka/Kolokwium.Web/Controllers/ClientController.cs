using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using AutoMapper;
using Kolokwium.Services.Interfaces;
using Kolokwium.ViewModel.VM.Order;
using Kolokwium.ViewModel.VM.Client;
using Kolokwium.Services.DTO.Client;
using Kolokwium.Services.ConcreteServices;
using Microsoft.AspNetCore.Mvc.ActionConstraints;


namespace Kolokwium.Web.Controllers
{
    public class ClientController : BaseController
    {
        private readonly IClientService _clientService;
        public ClientController(
            IClientService clientService,
            ILogger<ClientService> logger,
            IMapper mapper,
            IStringLocalizer<ClientController> localizer) : base(logger, mapper, localizer)
        {
            _clientService = clientService;
        }
        
        public async Task<IActionResult> Index()
        {
            var dtos = await _clientService.GetAllAsync();
            var vms = Mapper.Map<IEnumerable<ClientVm>>(dtos);
            return View(vms);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var orders = await _clientService.GetOrdersAsync();
            ViewBag.Orders = Mapper.Map<List<OrderVm>>(orders);
            return View(new CreateClientVm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateClientVm vm)
        {
            if (!ModelState.IsValid)
            {
                var orders = await _clientService.GetOrdersAsync();
                ViewBag.Orders = Mapper.Map<List<OrderVm>>(orders);
                return View(vm);
            }

            var dto = Mapper.Map<CreateClientDto>(vm);
            await _clientService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete (int id)
        {
            var result = await _clientService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}