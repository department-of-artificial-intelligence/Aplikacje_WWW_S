using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.Building;
using Services.Interfaces;
using Web.ViewModels.Building;
using Web.ViewModels.Room;

namespace Web.Controllers
{
    public class BuildingsController : BaseController
    {
        private readonly IBuildingService _buildingService;
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public BuildingsController(
            IBuildingService buildingService,
            IRoomService roomService,
            IMapper mapper,
            IWebHostEnvironment env) : base(env)
        {
            _buildingService = buildingService;
            _roomService = roomService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var dtos = await _buildingService.GetAllAsync();
            var viewModels = _mapper.Map<List<BuildingListItemViewModel>>(dtos);
            return View(viewModels);
        }

        public async Task<IActionResult> Details(int id)
        {
            var buildingDto = await _buildingService.GetByIdAsync(id);
            if (buildingDto == null) return NotFound();

            var viewModel = _mapper.Map<BuildingDetailsViewModel>(buildingDto);

            // Pobranie sal przypisanych do budynku i zmapowanie ich na ViewModel
            var roomsDtos = await _roomService.GetByBuildingIdAsync(id);
            viewModel.Rooms = _mapper.Map<List<RoomListItemViewModel>>(roomsDtos);

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View(new CreateBuildingViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBuildingViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var dto = _mapper.Map<CreateBuildingDto>(model);
            await _buildingService.CreateAsync(dto);
            SetSuccessMessage("Budynek zosta³ utworzony.");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _buildingService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var viewModel = _mapper.Map<EditBuildingViewModel>(dto);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditBuildingViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var dto = _mapper.Map<UpdateBuildingDto>(model);
            var success = await _buildingService.UpdateAsync(dto);

            if (success)
            {
                SetSuccessMessage("Budynek zosta³ zaktualizowany.");
                return RedirectToAction(nameof(Index));
            }

            SetErrorMessage("Wyst¹pi³ b³¹d podczas aktualizacji budynku.");
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _buildingService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var viewModel = _mapper.Map<DeleteBuildingViewModel>(dto);
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _buildingService.DeleteAsync(id);
            if (success) SetSuccessMessage("Budynek zosta³ usuniêty.");
            else SetErrorMessage("Nie uda³o siê usun¹æ budynku. Upewnij siê, ¿e nie ma przypisanych sal.");

            return RedirectToAction(nameof(Index));
        }
    }
}