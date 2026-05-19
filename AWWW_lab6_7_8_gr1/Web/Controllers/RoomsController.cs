using AutoMapper;
using Microsoft.AspNetCore.Hosting;
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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CreateRoomViewModel
            {
                Buildings = await CreateBuildingSelectListAsync(null)
            };
            return View(model);
        }

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
            return RedirectToAction("Index", "Home");
        }

        private async Task<List<SelectListItem>> CreateBuildingSelectListAsync(int? selectedId)
        {
            var buildings = await _buildingService.GetAllAsync();
            return buildings.Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Name,
                Selected = selectedId.HasValue && b.Id == selectedId.Value
            }).ToList();
        }
    }
}