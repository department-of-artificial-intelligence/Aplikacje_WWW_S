using DAL;
using Microsoft.EntityFrameworkCore;
using Model;
using Services.DTO.Reservation;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ActualServices
{
    public class ReservationService : BaseService, IReservationService
    {
        public ReservationService(AppDbContext dbContext) : base(dbContext) { }

        public async Task<List<ReservationDTO>> GetAllAsync()
        {
            return await _dbContext.Reservations
                .OrderBy(r => r.CreatedAt)
                .Select(r => new ReservationDTO
                {
                    Id = r.Id,
                    StartTime = r.StartTime,
                    EndTime = r.EndTime,
                    Status = (ReservationStatus)Enum.Parse(typeof(ReservationStatus), r.Status),
                    CreatedAt = r.CreatedAt,
                    Notes = r.Notes
                })
                .ToListAsync();
        }

        public async Task<ReservationDetailsDTO?> GetByIdAsync(int id)
        {
            var r = await _dbContext.Reservations.FindAsync(id);
            if (r == null) return null;

            return new ReservationDetailsDTO
            {
                Id = r.Id,
                RoomId = r.RoomId,
                EventId = r.EventId,
                StartTime = r.StartTime,
                EndTime = r.EndTime,
                Status = (ReservationStatus)Enum.Parse(typeof(ReservationStatus), r.Status),
                CreatedAt = r.CreatedAt,
                Notes = r.Notes
            };
        }

        public async Task<int> CreateAsync(CreateReservationDTO dto)
        {
            if (dto.EndTime <= dto.StartTime)
                throw new InvalidOperationException("EndTime must be later than StartTime.");

            var room = await _dbContext.Rooms.FindAsync(dto.RoomId);
            if (room == null)
                throw new InvalidOperationException("Room does not exist.");

            if (!room.IsActive)
                throw new InvalidOperationException("Room is not active.");

            var ev = await _dbContext.Events.FindAsync(dto.EventId);
            if (ev == null)
                throw new InvalidOperationException("Event does not exist.");

            if (ev.ParticipantsLimit > room.Capacity)
                throw new InvalidOperationException("Room capacity is too small for event.");

            bool overlaps = await _dbContext.Reservations
                .AnyAsync(r =>
                    r.RoomId == dto.RoomId &&
                    r.Status != "Cancelled" &&
                    r.Status != "Rejected" &&
                    r.StartTime < dto.EndTime &&
                    dto.StartTime < r.EndTime
                );

            if (overlaps)
                throw new InvalidOperationException("Room is already booked in this time range.");

            var reservation = new Reservation
            {
                RoomId = dto.RoomId,
                EventId = dto.EventId,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                Notes = dto.Notes,
                Status = ReservationStatus.Pending.ToString()
            };

            await _dbContext.Reservations.AddAsync(reservation);
            await _dbContext.SaveChangesAsync();

            return reservation.Id;
        }

        public async Task<bool> UpdateAsync(UpdateReservationDTO dto)
        {
            var r = await _dbContext.Reservations.FindAsync(dto.Id);
            if (r == null) return false;

            if (dto.EndTime <= dto.StartTime)
                throw new InvalidOperationException("EndTime must be later than StartTime.");

            r.StartTime = dto.StartTime;
            r.EndTime = dto.EndTime;
            r.Notes = dto.Notes;
            r.Status = dto.Status.ToString();

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> CancelAsync(int id)
        {
            var r = await _dbContext.Reservations.FindAsync(id);
            if (r == null) return false;

            r.Status = ReservationStatus.Cancelled.ToString();

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var r = await _dbContext.Reservations.FindAsync(id);
            if (r == null) return false;

            base._dbContext.Reservations.Remove(r);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}