using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using Services.DTO.Room;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels.Room;

namespace Web.Controllers
{
    public class RoomController : BaseController
    {
        private readonly IRoomService _roomService;
        private readonly IBuildingService _buildingService;
        private readonly IMapper _mapper;

        public RoomController(
            IRoomService roomService,
            IBuildingService buildingService,
            IMapper mapper,
            IWebHostEnvironment env) : base(env)
        {
            _roomService = roomService;
            _buildingService = buildingService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var dtos = await _roomService.GetAllAsync();
            var viewModels = _mapper.Map<List<IndexRoomViewModel>>(dtos);
            return View(viewModels);
        }

        public async Task<IActionResult> Details(int id)
        {
            var dto = await _roomService.GetByIdAsync(id);
            if (dto == null)
            {
                SetErrorMessage("Nie odnaleziono wskazanej sali.");
                return RedirectToAction(nameof(Index));
            }

            var viewModel = _mapper.Map<DetailsRoomViewModel>(dto);
            return View(viewModel);
        }

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

            try
            {
                var dto = _mapper.Map<CreateRoomDto>(model);
                await _roomService.CreateAsync(dto);
                SetSuccessMessage("Sala została utworzona.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                SetErrorMessage("Wystąpił błąd podczas tworzenia sali.");
                model.Buildings = await CreateBuildingSelectListAsync(model.BuildingId);
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _roomService.GetByIdAsync(id);
            if (dto == null)
            {
                SetErrorMessage("Nie odnaleziono sali do edycji.");
                return RedirectToAction(nameof(Index));
            }

            var model = _mapper.Map<EditRoomViewModel>(dto);
            model.Buildings = await CreateBuildingSelectListAsync(model.BuildingId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditRoomViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Buildings = await CreateBuildingSelectListAsync(model.BuildingId);
                return View(model);
            }

            try
            {
                bool success;
                if (typeof(IRoomService).GetMethod("UpdateAsync")?.GetParameters()[0].ParameterType.Name == "UpdateRoomDto")
                {
                    var dto = _mapper.Map<UpdateRoomDto>(model);
                    success = await _roomService.UpdateAsync(dto as dynamic);
                }
                else
                {
                    var dto = _mapper.Map<RoomDto>(model);
                    success = await _roomService.UpdateAsync(dto as dynamic);
                }

                if (success)
                {
                    SetSuccessMessage("Zmiany w danych sali zostały zapisane.");
                    return RedirectToAction(nameof(Index));
                }

                SetErrorMessage("Nie udało się zaktualizować danych sali.");
            }
            catch (Exception)
            {
                SetErrorMessage("Wystąpił błąd podczas zapisu zmian.");
            }

            model.Buildings = await CreateBuildingSelectListAsync(model.BuildingId);
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _roomService.GetByIdAsync(id);
            if (dto == null)
            {
                SetErrorMessage("Nie odnaleziono wskazanej sali.");
                return RedirectToAction(nameof(Index));
            }

            var model = _mapper.Map<DeleteRoomViewModel>(dto);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var success = await _roomService.DeleteAsync(id);
                if (success)
                {
                    SetSuccessMessage("Sala została pomyślnie usunięta.");
                }
                else
                {
                    SetErrorMessage("Nie udało się usunąć wskazanej sali.");
                }
            }
            catch (Exception)
            {
                SetErrorMessage("Nie można usunąć sali (prawdopodobnie istnieją powiązane rezerwacje).");
            }
            return RedirectToAction(nameof(Index));
        }

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