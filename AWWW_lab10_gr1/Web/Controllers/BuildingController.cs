using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.Building;
using Services.Interfaces;
using Web.ViewModels.Building;

namespace Web.Controllers
{
    public class BuildingController : BaseController
    {
        private readonly IBuildingService _buildingService;
        private readonly IMapper _mapper;

        public BuildingController(
            IBuildingService buildingService,
            IMapper mapper,
            IWebHostEnvironment env) : base(env)
        {
            _buildingService = buildingService;
            _mapper = mapper;
        }

        // LISTA
        public async Task<IActionResult> Index()
        {
            var dtos = await _buildingService.GetAllAsync();
            var vm = _mapper.Map<List<BuildingListItemViewModel>>(dtos);

            return View(vm);
        }

        // SZCZEGÓŁY
        public async Task<IActionResult> Details(int id)
        {
            var dto = await _buildingService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            return View(_mapper.Map<BuildingDetailsViewModel>(dto));
        }

        // CREATE - GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBuildingViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var dto = _mapper.Map<CreateBuildingDto>(vm);
            await _buildingService.CreateAsync(dto);

            SetSuccessMessage("Budynek dodany pomyślnie");
            return RedirectToAction(nameof(Index));
        }

        // EDIT - GET
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _buildingService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            return View(_mapper.Map<EditBuildingViewModel>(dto));
        }

        // EDIT - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditBuildingViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var dto = _mapper.Map<UpdateBuildingDto>(vm);
            await _buildingService.UpdateAsync(dto);

            SetSuccessMessage("Budynek zaktualizowany");
            return RedirectToAction(nameof(Index));
        }

        // DELETE - GET
        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _buildingService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            return View(_mapper.Map<BuildingDetailsViewModel>(dto));
        }

        // DELETE - POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _buildingService.DeleteAsync(id);

            SetSuccessMessage("Budynek usunięty");
            return RedirectToAction(nameof(Index));
        }
    }
}