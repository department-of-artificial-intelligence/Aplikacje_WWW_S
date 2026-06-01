using AutoMapper;
using Kolokwium.Services.DTO.Registration;
using Kolokwium.Services.Interfaces;
using Kolokwium.Web.ViewModels.Registration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Kolokwium.Web.Controllers
{
    public class RegistrationController : BaseController
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(
          IRegistrationService registrationService,
          ILogger<RegistrationController> logger,
          IMapper mapper,
          IStringLocalizer localizer,
          IWebHostEnvironment env)
          : base(logger, mapper, localizer, env)
        {
            _registrationService = registrationService;

        }

        // =======================================================
        // TWORZENIE (GET): Musi przyjąć carId z linku (np. /Registration/Create?carId=5)
        // =======================================================
        public IActionResult Create(int carId)
        {
            var model = new CreateRegistrationViewModel
            {
                CarId = carId
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRegistrationViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var dto = Mapper.Map<RegistrationDto>(model);

                // POPRAWIONO: Przekazujemy DTO ORAZ model.CarId jako drugi parametr!
                await _registrationService.CreateAsync(dto, model.CarId);

                SetSuccessMessage("Pomyślnie dodano dowód rejestracyjny."); // Poprawiono tekst

                // Po dodaniu dowodu przekierowujemy użytkownika z powrotem do szczegółów tego auta!
                return RedirectToAction("Details", "Car", new { id = model.CarId });
            }
            catch (Exception)
            {
                SetErrorMessage("Wystąpił nieoczekiwany błąd podczas dodawania.");
                return View(model);
            }
        }
    }
}
