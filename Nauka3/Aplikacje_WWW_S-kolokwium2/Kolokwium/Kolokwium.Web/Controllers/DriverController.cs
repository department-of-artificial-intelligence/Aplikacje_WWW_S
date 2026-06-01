using AutoMapper;
using Kolokwium.Services.DTO.Driver;
using Kolokwium.Services.Interfaces;
using Kolokwium.Web.ViewModels.Driver;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Kolokwium.Web.Controllers
{
    public class DriverController : BaseController
    {
        private readonly IDriverService _driverService;

        public DriverController(
          IDriverService driverService,
          ILogger<DriverController> logger,
          IMapper mapper,
          IStringLocalizer localizer,
          IWebHostEnvironment env)
          : base(logger, mapper, localizer, env)
        {
            _driverService = driverService;

        }

        public async Task<IActionResult> Index()
        {
            var driversDto = await _driverService.GetAllAsync();

            var viewModel = new IndexDriverViewModel
            {
                Drivers = Mapper.Map<List<DriverDto>>(driversDto)
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var driverDto = await _driverService.GetByIdAsync(id); 
            if (driverDto == null)
            {
                SetErrorMessage("Nie odnaleziono szukanego kierowcy.");
                return RedirectToAction(nameof(Index));
            }

            var viewModel = Mapper.Map<DetailsDriverViewModel>(driverDto);
            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDriverViewModel model)
        {
            if (!ModelState.IsValid)return View(model);

            try
            {
                var dto = Mapper.Map<CreateDriverDto>(model);
                await _driverService.CreateAsync(dto);
                SetSuccessMessage("Pomyślnie dodano nowego kierowce.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                SetErrorMessage("Wystąpił nieoczekiwany błąd podczas dodawania.");
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _driverService.GetByIdAsync(id);
            if (dto == null)
            {
                SetErrorMessage("Nie odnaleziono kierowcy do edycji.");
                return RedirectToAction(nameof(Index));
            }

            var model = Mapper.Map<EditDriverViewModel>(dto); 
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditDriverViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var dto = Mapper.Map<UpdateDriverDto>(model);
                var success = await _driverService.UpdateAsync(dto);

                if (success)
                {
                    SetSuccessMessage("Zmiany w danych zostały zapisane.");
                    return RedirectToAction(nameof(Index));
                }

                SetErrorMessage("Nie udało się zaktualizować danych.");
            }
            catch (Exception)
            {
                SetErrorMessage("Wystąpił błąd podczas zapisu zmian.");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _driverService.GetByIdAsync(id);
            if (dto == null)
            {
                SetErrorMessage("Nie odnaleziono kierowcy do usunięcia."); 
                return RedirectToAction(nameof(Index));
            }

            var model = Mapper.Map<DeleteDriverViewModel>(dto); 
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var success = await _driverService.DeleteAsync(id);
                if (success)
                {
                    SetSuccessMessage("Kierowca został trwale usunięty z systemu."); 
                }
                else
                {
                    SetErrorMessage("Nie udało się usunąć wskazanego kierowcy."); 
                }
            }
            catch (Exception)
            {
                SetErrorMessage("Nie można usunąć kierowcy."); 
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
