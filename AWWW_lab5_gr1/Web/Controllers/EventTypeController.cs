using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.EventType;
using Services.Interfaces;
using Web.ViewModels.EventType;

namespace Web.Controllers
{
    public class EventTypeController : BaseController
    {
        private readonly IEventTypeService _service;
        private readonly IMapper _mapper;

        public EventTypeController(IEventTypeService service, IMapper mapper, IWebHostEnvironment env) : base(env)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var dtos = await _service.GetAllAsync();
            return View(_mapper.Map<List<EventTypeListItemViewModel>>(dtos));
        }

        public async Task<IActionResult> Details(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();
            return View(_mapper.Map<EventTypeDetailsViewModel>(dto));
        }

        public IActionResult Create() => View(new CreateEventTypeViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEventTypeViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            await _service.CreateAsync(_mapper.Map<CreateEventTypeDto>(model));
            SetSuccessMessage("Typ wydarzenia zosta³ utworzony.");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();
            return View(_mapper.Map<EditEventTypeViewModel>(dto));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditEventTypeViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var success = await _service.UpdateAsync(_mapper.Map<UpdateEventTypeDto>(model));
            if (success) { SetSuccessMessage("Typ wydarzenia zaktualizowany."); return RedirectToAction(nameof(Index)); }
            SetErrorMessage("B³¹d podczas aktualizacji.");
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();
            return View(_mapper.Map<DeleteEventTypeViewModel>(dto));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (success) SetSuccessMessage("Typ wydarzenia usuniêty.");
            else SetErrorMessage("Nie uda³o siê usun¹æ typu wydarzenia.");
            return RedirectToAction(nameof(Index));
        }
    }
}