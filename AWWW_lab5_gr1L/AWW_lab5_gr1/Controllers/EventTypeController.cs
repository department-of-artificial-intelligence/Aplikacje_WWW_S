using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Services.DTO.EventType; 
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.ViewModels.EventType;

namespace Web.Controllers
{
    public class EventTypeController : BaseController
    {
        private readonly IEventTypeService _eventTypeService;
        private readonly IMapper _mapper;

        public EventTypeController(
            IEventTypeService eventTypeService,
            IMapper mapper,
            IWebHostEnvironment env) : base(env)
        {
            _eventTypeService = eventTypeService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var dtos = await _eventTypeService.GetAllAsync();
            var viewModels = _mapper.Map<List<IndexEventTypeViewModel>>(dtos);
            return View(viewModels);
        }

        public async Task<IActionResult> Details(int id)
        {
            var dto = await _eventTypeService.GetByIdAsync(id);
            if (dto == null)
            {
                SetErrorMessage("Nie odnaleziono wskazanego typu wydarzenia.");
                return RedirectToAction(nameof(Index));
            }

            var viewModel = _mapper.Map<DetailsEventTypeViewModel>(dto);
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEventTypeViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var dto = _mapper.Map<CreateEventTypeDto>(model); 
                await _eventTypeService.CreateAsync(dto);
                SetSuccessMessage("Pomyślnie dodano nowy typ wydarzenia.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                SetErrorMessage("Wystąpił nieoczekiwany błąd podczas dodawania typu wydarzenia.");
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _eventTypeService.GetByIdAsync(id);
            if (dto == null)
            {
                SetErrorMessage("Nie odnaleziono typu wydarzenia do edycji.");
                return RedirectToAction(nameof(Index));
            }

            var model = _mapper.Map<EditEventTypeViewModel>(dto);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditEventTypeViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var dto = _mapper.Map<UpdateEventTypeDto>(model);

                var success = await _eventTypeService.UpdateAsync(dto);

                if (success)
                {
                    SetSuccessMessage("Zmiany w typie wydarzenia zostały zapisane.");
                    return RedirectToAction(nameof(Index));
                }

                SetErrorMessage("Nie udało się zaktualizować typu wydarzenia.");
            }
            catch (Exception)
            {
                SetErrorMessage("Wystąpił błąd podczas zapisu zmian.");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _eventTypeService.GetByIdAsync(id);
            if (dto == null)
            {
                SetErrorMessage("Nie odnaleziono typu wydarzenia do usunięcia.");
                return RedirectToAction(nameof(Index));
            }

            var model = _mapper.Map<DeleteEventTypeViewModel>(dto);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var success = await _eventTypeService.DeleteAsync(id);
                if (success)
                {
                    SetSuccessMessage("Typ wydarzenia został pomyślnie usunięty.");
                }
                else
                {
                    SetErrorMessage("Nie udało się usunąć wskazanego typu wydarzenia.");
                }
            }
            catch (Exception)
            {
                SetErrorMessage("Nie można usunąć tego typu (prawdopodobnie istnieją powiązane rezerwacje).");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}