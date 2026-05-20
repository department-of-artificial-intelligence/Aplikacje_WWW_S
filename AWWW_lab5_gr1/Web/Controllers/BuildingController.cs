using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.Building;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        // GET: Buildings
        public async Task<IActionResult> Index()
        {
            var dtos = await _buildingService.GetAllAsync();
            var viewModels = _mapper.Map<IList<BuildingViewModel>>(dtos);
            return View(viewModels);
        }

        // GET: Buildings/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var buildingDto = await _buildingService.GetByIdAsync(id);
            if (buildingDto == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<DetailsBuildingViewModel>(buildingDto);

            // Ręczne dociąganie i mapowanie sal powiązanych z tym budynkiem (unikamy konfliktów AutoMappera)
            var roomsDto = await _roomService.GetByBuildingIdAsync(id);
            model.Rooms = _mapper.Map<List<RoomViewModel>>(roomsDto);

            return View(model);
        }

        // GET: Buildings/Create
        public IActionResult Create()
        {
            return View(new CreateBuildingViewModel());
        }

        // POST: Buildings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBuildingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = _mapper.Map<CreateBuildingDto>(model);
            await _buildingService.CreateAsync(dto);

            // Metoda SetSuccessMessage pochodzi najprawdopodobniej z Twojej klasy BaseController
            SetSuccessMessage("Budynek został utworzony.");
            return RedirectToAction(nameof(Index));
        }

        // GET: Buildings/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _buildingService.GetByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<EditBuildingViewModel>(dto);
            return View(model);
        }

        // POST: Buildings/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditBuildingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = _mapper.Map<UpdateBuildingDto>(model);
            var result = await _buildingService.UpdateAsync(dto);

            if (!result)
            {
                return NotFound();
            }

            SetSuccessMessage("Budynek został zaktualizowany.");
            return RedirectToAction(nameof(Index));
        }

        // GET: Buildings/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _buildingService.GetByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<BuildingViewModel>(dto);
            return View(model);
        }

        // POST: Buildings/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _buildingService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }

            SetSuccessMessage("Budynek został usunięty.");
            return RedirectToAction(nameof(Index));
        }
    }
}