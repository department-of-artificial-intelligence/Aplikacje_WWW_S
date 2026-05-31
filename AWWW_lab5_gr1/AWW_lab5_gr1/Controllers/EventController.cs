using AutoMapper;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using Services.DTO.Event;
using Services.Interfaces;
using Web.ViewModels.Event;

namespace Web.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEventService _eventService;
        private readonly IReservationService _reservationService;
        private readonly IEventTypeService _eventTypeService;
        private readonly IMapper _mapper;

        public EventController(
            IEventService eventService,
            IReservationService reservationService,
            IEventTypeService eventTypeService,
            IMapper mapper,
            IWebHostEnvironment env) : base(env)
        {
            _eventService = eventService;
            _reservationService = reservationService;
            _eventTypeService = eventTypeService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var dtos = await _eventService.GetAllAsync();
            return View(_mapper.Map<List<IndexEventViewModel>>(dtos));
        }


        public async Task<IActionResult> Details(int id)
        {
            var dto = await _eventService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var model = _mapper.Map<DetailsEventViewModel>(dto);
            var resDtos = await _reservationService.GetByEventIdAsync(id);
            model.Reservations = _mapper.Map<List<EventReservationItemViewModel>>(resDtos);

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var model = new CreateEventViewModel
            {
                EventTypes = await GetEventTypesSelectListAsync(),
                IsPublic = true 
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.EventTypes = await GetEventTypesSelectListAsync();
                return View(model);
            }

            try
            {
                var dto = _mapper.Map<CreateEventDto>(model);
                await _eventService.CreateAsync(dto);
                SetSuccessMessage("Wydarzenie zostało utworzone.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                SetErrorMessage(ex.Message ?? "Wystąpił nieoczekiwany błąd podczas tworzenia wydarzenia.");
                model.EventTypes = await GetEventTypesSelectListAsync();
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _eventService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var model = _mapper.Map<EditEventViewModel>(dto);
            model.EventTypes = await GetEventTypesSelectListAsync(); 

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.EventTypes = await GetEventTypesSelectListAsync();
                return View(model);
            }

            try
            {
                var dto = _mapper.Map<UpdateEventDto>(model);
                await _eventService.UpdateAsync(dto);
                SetSuccessMessage("Zmiany zostały zapisane.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                SetErrorMessage(ex.Message ?? "Wystąpił nieoczekiwany błąd podczas zapisu zmian.");
                model.EventTypes = await GetEventTypesSelectListAsync();
                return View(model);
            }
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _eventService.DeleteAsync(id);
            SetSuccessMessage("Wydarzenie zostało usunięte.");
            return RedirectToAction(nameof(Index));
        }

        private async Task<List<SelectListItem>> GetEventTypesSelectListAsync()
        {
            var types = await _eventTypeService.GetAllAsync();
            return types.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Name
            }).ToList();
        }
    }
}
