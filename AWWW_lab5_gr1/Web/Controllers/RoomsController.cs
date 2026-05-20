using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.DTO.Room;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels.Room;

namespace Web.Controllers
{
    public class RoomsController : BaseController
    {
        private readonly IRoomService _roomService;
        private readonly IBuildingService _buildingService;
        private readonly IMapper _mapper;

        public RoomsController(
            IRoomService roomService,
            IBuildingService buildingService,
            IMapper mapper,
            IWebHostEnvironment env) : base(env)
        {
            _roomService = roomService;
            _buildingService = buildingService;
            _mapper = mapper;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
            var dtos = await _roomService.GetAllAsync();
            var viewModels = _mapper.Map<IList<RoomViewModel>>(dtos);
            return View(viewModels);
        }

        // GET: Rooms/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var dto = await _roomService.GetByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<DetailsRoomViewModel>(dto);
            return View(viewModel);
        }

        // GET: Rooms/Create (Zgodnie z Rys. 16)
        public async Task<IActionResult> Create()
        {
            var model = new CreateRoomViewModel
            {
                Buildings = await CreateBuildingSelectListAsync(null)
            };

            return View(model);
        }

        // POST: Rooms/Create (Zgodnie z Rys. 16)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRoomViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Buildings = await CreateBuildingSelectListAsync(model.BuildingId);
                return View(model);
            }

            var dto = _mapper.Map<CreateRoomDto>(model);
            await _roomService.CreateAsync(dto);
            SetSuccessMessage("Sala została utworzona.");

            return RedirectToAction(nameof(Index));
        }

        // GET: Rooms/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _roomService.GetByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<EditRoomViewModel>(dto);
            model.Buildings = await CreateBuildingSelectListAsync(model.BuildingId);
            return View(model);
        }

        // POST: Rooms/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditRoomViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Buildings = await CreateBuildingSelectListAsync(model.BuildingId);
                return View(model);
            }

            var dto = _mapper.Map<UpdateRoomDto>(model);
            var result = await _roomService.UpdateAsync(dto);

            if (!result)
            {
                return NotFound();
            }

            SetSuccessMessage("Sala została zaktualizowana.");
            return RedirectToAction(nameof(Index));
        }

        // GET: Rooms/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _roomService.GetByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<DetailsRoomViewModel>(dto);
            return View(model);
        }

        // POST: Rooms/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _roomService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }

            SetSuccessMessage("Sala została usunięta.");
            return RedirectToAction(nameof(Index));
        }

        // Metoda pomocnicza pobierająca budynki (Zgodnie z Rys. 16)
        private async Task<List<SelectListItem>> CreateBuildingSelectListAsync(int? selectedId)
        {
            var buildings = await _buildingService.GetAllAsync();
            return buildings
                .Select(b => new SelectListItem
                {
                    Value = b.Id.ToString(),
                    Text = b.Name,
                    Selected = selectedId.HasValue && b.Id == selectedId.Value
                })
                .ToList();
        }
    }
}