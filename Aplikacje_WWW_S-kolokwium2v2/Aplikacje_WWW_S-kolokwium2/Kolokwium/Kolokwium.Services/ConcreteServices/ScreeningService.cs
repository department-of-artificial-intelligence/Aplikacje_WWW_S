using AutoMapper;
using Kolokwium.DAL;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.ConcreteServices;
using Kolokwium.Services.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging; // Wymagane dla ILogger
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Services
{
    public class ScreeningService : BaseService, IScreeningService
    {
        // Konstruktor przyjmuje teraz 3 parametry i przekazuje je poprawnie w górę
        public ScreeningService(ApplicationDbContext context, IMapper mapper, ILogger<ScreeningService> logger)
            : base(context, mapper, logger)
        {
        }

        public async Task<IEnumerable<ScreeningDto>> GetAllAsync()
        {
            var screenings = await DbContext.Screenings
                .Include(s => s.Cinema)
                .ToListAsync();
            return Mapper.Map<IEnumerable<ScreeningDto>>(screenings);
        }

        public async Task<ScreeningDto> GetByIdAsync(int id)
        {
            var screening = await DbContext.Screenings
                .Include(s => s.Cinema)
                .FirstOrDefaultAsync(s => s.Id == id);
            return Mapper.Map<ScreeningDto>(screening);
        }

        public async Task CreateAsync(ScreeningDto dto)
        {
            // 1. Mapujemy podstawowe pola (Tytuł, Data)
            var screening = Mapper.Map<Screening>(dto);

            // 2. Wymuszamy przypisanie ID kina bezpośrednio na klucz obcy
            screening.CinemaId = dto.CinemaId;

            // 3. Odpinamy obiekt kinowy, żeby EF wiedział, że ma go nie ruszać ani nie tworzyć
            screening.Cinema = null!;

            DbContext.Screenings.Add(screening);
            await DbContext.SaveChangesAsync();
        }
    }
}