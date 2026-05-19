using Microsoft.AspNetCore.Mvc;
using Services.DTO.Building;
using Services.Interfaces;

namespace Web.Controllers
{
    public class BuildingsController : BaseController
    {
        private readonly IBuildingService _buildingService;

        public BuildingsController(
            IWebHostEnvironment env,
            IBuildingService buildingService) : base(env)
        {
            _buildingService = buildingService;
        }

        public async Task<IActionResult> Index()
        {
            var buildings = await _buildingService.GetAllAsync();
            return View(buildings);
        }

        public async Task<IActionResult> Details(int id)
        {
            var building = await _buildingService.GetByIdAsync(id);

            if (building == null)
            {
                SetErrorMessage("Nie znaleziono budynku.");
                return RedirectToAction(nameof(Index));
            }

            return View(building);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBuildingDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _buildingService.CreateAsync(dto);

            SetSuccessMessage("Budynek został dodany.");

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var building = await _buildingService.GetByIdAsync(id);

            if (building == null)
            {
                SetErrorMessage("Nie znaleziono budynku.");
                return RedirectToAction(nameof(Index));
            }

            var dto = new UpdateBuildingDto
            {
                Id = building.Id,
                Name = building.Name,
                Address = building.Address,
                Description = building.Description
            };

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateBuildingDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _buildingService.UpdateAsync(dto);

            if (!result)
            {
                SetErrorMessage("Nie udało się edytować budynku.");
                return RedirectToAction(nameof(Index));
            }

            SetSuccessMessage("Budynek został zaktualizowany.");

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var building = await _buildingService.GetByIdAsync(id);

            if (building == null)
            {
                SetErrorMessage("Nie znaleziono budynku.");
                return RedirectToAction(nameof(Index));
            }

            return View(building);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _buildingService.DeleteAsync(id);

            if (!result)
            {
                SetErrorMessage("Nie udało się usunąć budynku.");
                return RedirectToAction(nameof(Index));
            }

            SetSuccessMessage("Budynek został usunięty.");

            return RedirectToAction(nameof(Index));
        }
    }
}