using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.EventType;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.ViewModels.EventType;

namespace Web.Controllers
{
    public class EventTypesController : BaseController
    {
        private readonly IEventTypeService _eventTypeService;
        private readonly IMapper _mapper;

        public EventTypesController(
            IEventTypeService eventTypeService,
            IMapper mapper,
            IWebHostEnvironment env) : base(env)
        {
            _eventTypeService = eventTypeService;
            _mapper = mapper;
        }

        // GET: EventTypes
        public async Task<IActionResult> Index()
        {
            var dtos = await _eventTypeService.GetAllAsync();
            var viewModels = _mapper.Map<IList<EventTypeViewModel>>(dtos);
            return View(viewModels);
        }

        // GET: EventTypes/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var dto = await _eventTypeService.GetByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<DetailsEventTypeViewModel>(dto);
            return View(viewModel);
        }

        // GET: EventTypes/Create
        public IActionResult Create()
        {
            return View(new CreateEventTypeViewModel());
        }

        // POST: EventTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEventTypeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = _mapper.Map<CreateEventTypeDto>(model);
            await _eventTypeService.CreateAsync(dto);

            SetSuccessMessage("Typ wydarzenia został utworzony.");
            return RedirectToAction(nameof(Index));
        }

        // GET: EventTypes/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _eventTypeService.GetByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<EditEventTypeViewModel>(dto);
            return View(model);
        }

        // POST: EventTypes/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditEventTypeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = _mapper.Map<UpdateEventTypeDto>(model);
            var result = await _eventTypeService.UpdateAsync(dto);

            if (!result)
            {
                return NotFound();
            }

            SetSuccessMessage("Typ wydarzenia został zaktualizowany.");
            return RedirectToAction(nameof(Index));
        }

        // GET: EventTypes/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _eventTypeService.GetByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<EventTypeViewModel>(dto);
            return View(model);
        }

        // POST: EventTypes/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var result = await _eventTypeService.DeleteAsync(id);
                if (!result)
                {
                    return NotFound();
                }

                SetSuccessMessage("Typ wydarzenia został usunięty.");
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                // Przekazanie błędu walidacji biznesowej (brak możliwości usunięcia powiązanych obiektów)
                ModelState.AddModelError(string.Empty, ex.Message);

                // Ponowne pobranie danych do widoku usunięcia po wystąpieniu błędu
                var dto = await _eventTypeService.GetByIdAsync(id);
                var model = _mapper.Map<EventTypeViewModel>(dto);
                return View(model);
            }
        }
    }
}