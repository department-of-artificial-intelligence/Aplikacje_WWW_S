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
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public BuildingController(
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
            var viewModels = _mapper.Map<List<IndexBuildingViewModel>>(dtos);
            return View(viewModels);
        }
        public async Task<IActionResult> Details(int id)
        {
            var buildingDto = await _buildingService.GetByIdAsync(id);
            if (buildingDto == null)
            {
                SetErrorMessage("Nie odnaleziono szukanego budynku.");
                return RedirectToAction(nameof(Index));
            }

            var viewModel = _mapper.Map<DetailsBuildingViewModel>(buildingDto);

            var roomDtos = await _roomService.GetByBuildingIdAsync(id);

            viewModel.Rooms = _mapper.Map<List<BuildingRoomItemViewModel>>(roomDtos);

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBuildingViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var dto = _mapper.Map<CreateBuildingDto>(model);
                await _buildingService.CreateAsync(dto);
                SetSuccessMessage("Pomyślnie dodano nowy budynek.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                SetErrorMessage("Wystąpił nieoczekiwany błąd podczas dodawania budynku.");
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _buildingService.GetByIdAsync(id);
            if (dto == null)
            {
                SetErrorMessage("Nie odnaleziono budynku do edycji.");
                return RedirectToAction(nameof(Index));
            }

            var model = _mapper.Map<EditBuildingViewModel>(dto);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditBuildingViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var dto = _mapper.Map<BuildingDto>(model);
                var success = await _buildingService.UpdateAsync(dto);

                if (success)
                {
                    SetSuccessMessage("Zmiany w danych budynku zostały zapisane.");
                    return RedirectToAction(nameof(Index));
                }

                SetErrorMessage("Nie udało się zaktualizować danych budynku.");
            }
            catch (Exception)
            {
                SetErrorMessage("Wystąpił błąd podczas zapisu zmian.");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _buildingService.GetByIdAsync(id); ;
            if (dto == null)
            {
                SetErrorMessage("Nie odnaleziono budynku do usunięcia.");
                return RedirectToAction(nameof(Index));
            }

            var model = _mapper.Map<DeleteBuildingViewModel>(dto);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var success = await _buildingService.DeleteAsync(id);
                if (success)
                {
                    SetSuccessMessage("Budynek został trwale usunięty z systemu.");
                }
                else
                {
                    SetErrorMessage("Nie udało się usunąć wskazanego budynku.");
                }
            }
            catch (Exception)
            {
                SetErrorMessage("Nie można usunąć budynku (prawdopodobnie posiada przypisane sale).");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
