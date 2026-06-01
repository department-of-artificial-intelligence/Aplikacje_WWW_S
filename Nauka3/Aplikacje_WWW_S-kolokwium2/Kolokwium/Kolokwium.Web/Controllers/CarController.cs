using AutoMapper;
using Kolokwium.Services.DTO.Car;
using Kolokwium.Services.Interfaces;
using Kolokwium.Services.Services;
using Kolokwium.Web.ViewModels.Car;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Kolokwium.Web.Controllers
{
    public class CarController : BaseController
    {
        private readonly ICarService _carService;
        private readonly IDriverService _driverService; // Dodano pod listę <select>

        public CarController(
          ICarService carService,
          IDriverService driverService,
          ILogger<CarController> logger, 
          IMapper mapper,
          IStringLocalizer localizer,
          IWebHostEnvironment env)
          : base(logger, mapper, localizer, env) 
        {
            _carService = carService;
            _driverService = driverService;

        }

        public async Task<IActionResult> Index()
        {
            var carsDto = await _carService.GetAllAsync();

            var viewModel = new IndexCarViewModel
            {
                Cars = Mapper.Map<List<CarDto>>(carsDto)
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var carDto = await _carService.GetByIdAsync(id); // Poprawiono nazwę zmiennej
            if (carDto == null)
            {
                SetErrorMessage("Nie odnaleziono szukanego auta.");
                return RedirectToAction(nameof(Index));
            }

            // POPRAWIONO: Mapper z wielkiej litery
            var viewModel = Mapper.Map<DetailsCarViewModel>(carDto);
            return View(viewModel);
        }

        // =======================================================
        // TWORZENIE (GET): Musi załadować kierowców do selecta!
        // =======================================================
        public async Task<IActionResult> Create()
        {
            var drivers = await _driverService.GetAllAsync();

            var model = new CreateCarViewModel
            {
                // Mapujemy kierowców na SelectListItem dla widoku HTML
                Drivers = drivers.Select(d => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = $"{d.FirstName} {d.LastName}"
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCarViewModel viewModel) // ZMIENIONO: model -> viewModel
        {
            if (!ModelState.IsValid)
            {
                // Ponowne ładowanie listy kierowców w przypadku błędu walidacji formularza
                var drivers = await _driverService.GetAllAsync();
                viewModel.Drivers = drivers.Select(d => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = $"{d.FirstName} {d.LastName}"
                }).ToList();
                return View(viewModel); // ZMIENIONO: model -> viewModel
            }

            try
            {
                var dto = Mapper.Map<CreateCarDto>(viewModel); // ZMIENIONO: model -> viewModel
                await _carService.CreateAsync(dto);
                SetSuccessMessage("Pomyślnie dodano nowe auto.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                SetErrorMessage("Wystąpił nieoczekiwany błąd podczas dodawania.");
                return View(viewModel); // ZMIENIONO: model -> viewModel
            }
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Ponowne ładowanie listy kierowców w przypadku błędu walidacji formularza
                var drivers = await _driverService.GetAllAsync();
                model.Drivers = drivers.Select(d => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = $"{d.FirstName} {d.LastName}"
                }).ToList();
                return View(model);
            }

            try
            {
                var dto = Mapper.Map<CreateCarDto>(model); // POPRAWIONO: Mapper
                await _carService.CreateAsync(dto);
                SetSuccessMessage("Pomyślnie dodano nowe auto.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                SetErrorMessage("Wystąpił nieoczekiwany błąd podczas dodawania.");
                return View(model);
            }
        }*/

        /*public async Task<IActionResult> Edit(int id)
        {
            var dto = await _carService.GetByIdAsync(id);
            if (dto == null)
            {
                SetErrorMessage("Nie odnaleziono auta do edycji.");
                return RedirectToAction(nameof(Index));
            }

            var model = Mapper.Map<EditCarViewModel>(dto); // POPRAWIONO: Mapper
            return View(model);
        }*/

        /* [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Edit(EditCarViewModel model)
         {
             if (!ModelState.IsValid) return View(model);

             try
             {
                 // POPRAWIONO: Zmieniono typ z CarDto na UpdateCarDto!
                 var dto = Mapper.Map<UpdateCarDto>(model);
                 var success = await _carService.UpdateAsync(dto);

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
         }*/


        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _carService.GetByIdAsync(id);
            if (dto == null)
            {
                SetErrorMessage("Nie odnaleziono auta do edycji.");
                return RedirectToAction(nameof(Index));
            }

            var model = Mapper.Map<EditCarViewModel>(dto);

            // DOCZYTUJEMY KIEROWCÓW DO SELECTA
            var drivers = await _driverService.GetAllAsync();
            model.Drivers = drivers.Select(d => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = d.Id.ToString(),
                Text = $"{d.FirstName} {d.LastName}"
            }).ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditCarViewModel viewModel) // ZMIENIONO: model -> viewModel
        {
            if (!ModelState.IsValid)
            {
                var drivers = await _driverService.GetAllAsync();
                viewModel.Drivers = drivers.Select(d => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = $"{d.FirstName} {d.LastName}"
                }).ToList();
                return View(viewModel);
            }

            try
            {
                // POPRAWIONO: Zmieniono typ z CarDto na UpdateCarDto!
                var dto = Mapper.Map<UpdateCarDto>(viewModel); // ZMIENIONO: model -> viewModel
                var success = await _carService.UpdateAsync(dto);

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
            return View(viewModel); // ZMIENIONO: model -> viewModel
        }
        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _carService.GetByIdAsync(id);
            if (dto == null)
            {
                SetErrorMessage("Nie odnaleziono auta do usunięcia."); // POPRAWIONO: tekst
                return RedirectToAction(nameof(Index));
            }

            var model = Mapper.Map<DeleteCarViewModel>(dto); // POPRAWIONO: Mapper
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var success = await _carService.DeleteAsync(id);
                if (success)
                {
                    SetSuccessMessage("Auto zostało trwale usunięte z systemu."); // POPRAWIONO: tekst
                }
                else
                {
                    SetErrorMessage("Nie udało się usunąć wskazanego pojazdu."); // POPRAWIONO: tekst
                }
            }
            catch (Exception)
            {
                SetErrorMessage("Nie można usunąć pojazdu (prawdopodobnie posiada powiązane dane)."); // POPRAWIONO: tekst
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
