using AutoMapper;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using Services.DTO.Reservation;
using Services.Interfaces;
using Web.ViewModels.Reservation;

namespace Web.Controllers
{
    public class ReservationController : BaseController
    {
        private readonly IReservationService _reservationService;
        private readonly IRoomService _roomService;
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public ReservationController(IReservationService reservationService, IRoomService roomService, IEventService eventService, IMapper mapper, IWebHostEnvironment env) : base(env)
        {
            _reservationService = reservationService;
            _roomService = roomService;
            _eventService = eventService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Create(int eventId)
        {
            var ev = await _eventService.GetByIdAsync(eventId);
            if (ev == null) return NotFound();

            var rooms = await _roomService.GetAllAsync();
            var model = new CreateReservationViewModel
            {
                EventId = eventId,
                EventName = ev.Title,
                Rooms = rooms.Select(r => new SelectListItem { Value = r.Id.ToString(), Text = $"{r.Name} ({r.BuildingName})" }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateReservationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var rooms = await _roomService.GetAllAsync();
                model.Rooms = rooms.Select(r => new SelectListItem { Value = r.Id.ToString(), Text = $"{r.Name}" }).ToList();
                return View(model);
            }

            try
            {
                var dto = new CreateReservationDto
                {
                    EventId = model.EventId,
                    RoomId = model.RoomId,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime
                };

                await _reservationService.CreateAsync(dto);
                SetSuccessMessage("Rezerwacja została zgłoszona i oczekuje na akceptację.");
                return RedirectToAction("Details", "Event", new { id = model.EventId });
            }
            catch (InvalidOperationException ex)
            {
                SetErrorMessage(ex.Message);
                var rooms = await _roomService.GetAllAsync();
                model.Rooms = rooms.Select(r => new SelectListItem { Value = r.Id.ToString(), Text = $"{r.Name}" }).ToList();
                return View(model);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int id, string status, int redirectEventId)
        {
            try
            {
                if (Enum.TryParse<Model.ReservationStatus>(status, true, out var statusEnum))
                {
                    await _reservationService.UpdateStatusAsync(id, statusEnum);
                    SetSuccessMessage("Status rezerwacji został zmieniony.");
                }
                else
                {
                    SetErrorMessage("Niepoprawny status rezerwacji.");
                }
            }
            catch (Exception ex)
            {
                SetErrorMessage(ex.Message);
            }

            return RedirectToAction("Details", "Event", new { id = redirectEventId });
        }
    }
}
