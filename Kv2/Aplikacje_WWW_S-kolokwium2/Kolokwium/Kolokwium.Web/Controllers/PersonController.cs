using AutoMapper;
using Kolokwium.Services.DTO;
using Kolokwium.Services.Interfaces;
using Kolokwium.Web.Controllers;
using Kolokwium.Web.ViewModels.Person;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Web.Controllers
{
    public class PersonController : BaseController
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;
        private readonly ILogger<PersonController> _logger;

        // 1. Dodajemy IStringLocalizer<PersonController> do parametrów
        // 2. Poprawiamy ILogger na typowany: ILogger<PersonController>
        public PersonController(
            IPersonService personService,
            IMapper mapper,
            ILogger<PersonController> logger,
            IStringLocalizer<PersonController> localizer)
            : base(logger, mapper, localizer) // Przekazujemy do bazy dokładnie tak, jak wymaga BaseController: Logger, Mapper, Localizer
        {
            _personService = personService;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: Person
        public async Task<IActionResult> Index()
        {
            var dtos = await _personService.GetAllAsync();
            var vms = _mapper.Map<IEnumerable<PersonViewModel>>(dtos);
            return View(vms);
        }

        // GET: Person/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var dto = await _personService.GetByIdAsync(id);
            if (dto == null) return NotFound(); // To znowu da 404, JEŚLI baza będzie pusta

            var model = _mapper.Map<DetailsPersonViewModel>(dto);
            return View(model);
        }

        // GET: Person/Create
        public IActionResult Create()
        {
            return View(new CreatePersonViewModel());
        }

        // POST: Person/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePersonViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var dto = _mapper.Map<CreatePersonDto>(model);
            await _personService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        // GET: Person/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _personService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var model = _mapper.Map<EditPersonViewModel>(dto);
            return View(model);
        }

        // POST: Person/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditPersonViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var dto = _mapper.Map<UpdatePersonDto>(model);
            await _personService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        // POST: Person/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _personService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}