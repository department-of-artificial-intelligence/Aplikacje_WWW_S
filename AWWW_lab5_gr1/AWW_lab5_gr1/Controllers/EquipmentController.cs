using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Services.DTO.Equipment;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.ViewModels.Equipment;

namespace Web.Controllers
{
    public class EquipmentController : BaseController
    {
        private readonly IEquipmentService _equipmentService;
        private readonly IMapper _mapper;

        public EquipmentController(
            IEquipmentService equipmentService,
            IMapper mapper,
            IWebHostEnvironment env) : base(env)
        {
            _equipmentService = equipmentService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var dtos = await _equipmentService.GetAllAsync();
            var viewModels = _mapper.Map<List<IndexEquipmentViewModel>>(dtos);
            return View(viewModels);
        }

        public async Task<IActionResult> Details(int id)
        {
            var dto = await _equipmentService.GetByIdAsync(id);
            if (dto == null)
            {
                SetErrorMessage("Nie odnaleziono wskazanego elementu wyposażenia.");
                return RedirectToAction(nameof(Index));
            }

            var viewModel = _mapper.Map<DetailsEquipmentViewModel>(dto);
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEquipmentViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var dto = _mapper.Map<CreateEquipmentDto>(model);
                await _equipmentService.CreateAsync(dto);
                SetSuccessMessage("Pomyślnie dodano nowe wyposażenie.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                SetErrorMessage("Wystąpił nieoczekiwany błąd podczas dodawania wyposażenia.");
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _equipmentService.GetByIdAsync(id);
            if (dto == null)
            {
                SetErrorMessage("Nie odnaleziono wyposażenia do edycji.");
                return RedirectToAction(nameof(Index));
            }

            var model = _mapper.Map<EditEquipmentViewModel>(dto);
            return model != null ? View(model) : RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditEquipmentViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                bool success;

                if (typeof(IEquipmentService).GetMethod("UpdateAsync")?.GetParameters()[0].ParameterType.Name == "UpdateEquipmentDto")
                {
                    var dto = _mapper.Map<UpdateEquipmentDto>(model);
                    success = await _equipmentService.UpdateAsync(dto as dynamic);
                }
                else
                {
                    var dto = _mapper.Map<EquipmentDto>(model);
                    success = await _equipmentService.UpdateAsync(dto as dynamic);
                }

                if (success)
                {
                    SetSuccessMessage("Zmiany w wyposażeniu zostały zapisane.");
                    return RedirectToAction(nameof(Index));
                }

                SetErrorMessage("Nie udało się zaktualizować wyposażenia.");
            }
            catch (Exception)
            {
                SetErrorMessage("Wystąpił błąd podczas zapisu zmian.");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _equipmentService.GetByIdAsync(id);
            if (dto == null)
            {
                SetErrorMessage("Nie odnaleziono wyposażenia do usunięcia.");
                return RedirectToAction(nameof(Index));
            }

            var model = _mapper.Map<DeleteEquipmentViewModel>(dto);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var success = await _equipmentService.DeleteAsync(id);
                if (success)
                {
                    SetSuccessMessage("Wyposażenie zostało pomyślnie usunięte.");
                }
                else
                {
                    SetErrorMessage("Nie udało się usunąć wskazanego wyposażenia.");
                }
            }
            catch (Exception)
            {
                SetErrorMessage("Nie można usunąć wyposażenia (jest obecnie przypisane do sal/rezerwacji).");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}