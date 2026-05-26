using AutoMapper;
using Kolokwium.Services; // ZAŁATWIA DOSTĘP DO IScreeningService
using Kolokwium.Services.DTO;
using Kolokwium.ViewModel.VM;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kolokwium.Web.Controllers
{
    public class ScreeningController : Controller
    {
        private readonly IScreeningService _screeningService;
        private readonly IMapper _mapper;

        public ScreeningController(IScreeningService screeningService, IMapper mapper)
        {
            _screeningService = screeningService;
            _mapper = mapper;
        }

        // GET: Screening
        public async Task<IActionResult> Index()
        {
            var dtos = await _screeningService.GetAllAsync();
            var viewModels = _mapper.Map<IEnumerable<ScreeningVm>>(dtos);
            return View(viewModels);
        }

        // GET: Screening/Create
        public IActionResult Create()
        {
            return View(new CreateScreeningVm());
        }

        // POST: Screening/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateScreeningVm model)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<ScreeningDto>(model);

                await _screeningService.CreateAsync(dto);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}