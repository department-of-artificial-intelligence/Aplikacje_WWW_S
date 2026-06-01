using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Services.DTO.RoomEquipment;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels.RoomEquipment;

namespace Web.Controllers
{
    public class RoomEquipmentController : BaseController
    {

        private readonly IRoomService _roomService;
        private readonly IEquipmentService _equipmentService;
        private readonly IRoomEquipmentService _roomEquipmentService;
        private readonly IMapper _mapper;

        public RoomEquipmentController(
            IRoomService roomService,
            IEquipmentService equipmentService,
            IRoomEquipmentService roomEquipmentService,
            IMapper mapper,
            IWebHostEnvironment env) : base(env)
        {
            _roomService = roomService;
            _equipmentService = equipmentService;
            _roomEquipmentService = roomEquipmentService;
            _mapper = mapper;
        }


        public async Task<IActionResult> Add(int roomId)
        {
            var model = await BuildModelAsync(roomId);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddRoomEquipmentsViewModel model)
        {
            var room = await _roomService.GetByIdAsync(model.RoomId);
            if (room == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                var rebuiltModel = await BuildModelAsync(model.RoomId);
                return View(rebuiltModel);
            }

            var selectedDtos = model.Items
                .Where(x => x.IsSelected)
                .Select(_mapper.Map<CreateRoomEquipmentDto>)
                .ToList();

            try
            {
                await _roomEquipmentService.AssignAsync(selectedDtos);
                SetSuccessMessage("Wyposażenie zostało przypisane do sali.");
            }
            catch (InvalidOperationException ex)
            {
                SetErrorMessage(ex.Message);
                var rebuiltModel = await BuildModelAsync(model.RoomId);
                return View(rebuiltModel);
            }
            catch (Exception)
            {
                SetErrorMessage("Wystąpił nieoczekiwany błąd podczas przypisywania wyposażenia.");
                var rebuiltModel = await BuildModelAsync(model.RoomId);
                return View(rebuiltModel);
            }

            return RedirectToAction("Details", "Room", new { id = model.RoomId });
        }

        public async Task<IActionResult> Edit(int roomId, int equipmentId)
        {
            var room = await _roomService.GetByIdAsync(roomId);
            if (room == null) return NotFound();

            var assignedEquipment = await _roomEquipmentService.GetByRoomIdAsync(roomId);
            var currentItem = assignedEquipment.FirstOrDefault(x => x.EquipmentId == equipmentId);
            if (currentItem == null) return NotFound();

            var model = new EditRoomEquipmentViewModel
            {
                RoomId = roomId,
                EquipmentId = equipmentId,
                RoomName = room.Name,
                EquipmentName = currentItem.EquipmentName,
                Quantity = currentItem.Quantity
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditRoomEquipmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _roomEquipmentService.UpdateQuantityAsync(model.RoomId, model.EquipmentId, model.Quantity);
                SetSuccessMessage("Ilość wyposażenia została zaktualizowana.");
                return RedirectToAction("Details", "Room", new { id = model.RoomId });
            }
            catch (Exception ex)
            {
                SetErrorMessage(ex.Message ?? "Wystąpił błąd podczas aktualizacji ilości.");
                return View(model);
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int roomId, int equipmentId)
        {
            try
            {
                await _roomEquipmentService.DeleteAsync(roomId, equipmentId);
                SetSuccessMessage("Wyposażenie zostało usunięte z sali.");
            }
            catch (Exception ex)
            {
                SetErrorMessage(ex.Message ?? "Nie udało się usunąć wyposażenia z sali.");
            }

            return RedirectToAction("Details", "Room", new { id = roomId });
        }

        private async Task<AddRoomEquipmentsViewModel?> BuildModelAsync(int roomId)
        {
            var room = await _roomService.GetByIdAsync(roomId);
            if (room == null) return null;

            var allEquipment = await _equipmentService.GetAllAsync();
            var alreadyAssigned = await _roomEquipmentService.GetByRoomIdAsync(roomId);
            var assignedIds = alreadyAssigned.Select(x => x.EquipmentId).ToHashSet();

            var availableEquipment = allEquipment
                .Where(x => !assignedIds.Contains(x.Id))
                .ToList();

            var items = _mapper.Map<List<AddRoomEquipmentRowViewModel>>(availableEquipment);
            foreach (var item in items)
            {
                item.RoomId = roomId;
            }

            return new AddRoomEquipmentsViewModel
            {
                RoomId = room.Id,
                RoomName = room.Name,
                BuildingName = room.BuildingName,
                Items = items
            };
        }
    }
}
