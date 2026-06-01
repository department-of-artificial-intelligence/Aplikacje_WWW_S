using AutoMapper;
using Kolokwium.DAL;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.DTO.Book;
using Kolokwium.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Services.Services
{
    public class BookService : BaseService, IBookService
    {
        public BookService(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
        public async Task<List<BookDto>> GetAllAsync()
        {
            return await _dbContext.Books
                .AsNoTracking()
                .OrderBy(x => x.Title)
                .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<BookDetailsDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Books
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ProjectTo<BookDetailsDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateBookDto dto)
        {
            var entity = _mapper.Map<Book>(dto);

            // LOGIKA RELACJI WIELE-DO-WIELU:
            if (dto.AuthorIds != null && dto.AuthorIds.Any())
            {
                // Pobieramy z bazy encje autorów o pasujących ID
                var authors = await _dbContext.Authors
                    .Where(a => dto.AuthorIds.Contains(a.Id))
                    .ToListAsync();

                // Przypisujemy pobraną listę do encji książki
                entity.Authors = authors;
            }

            _dbContext.Books.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateBookDto dto)
        {
            // Dociągamy encję razem z jej dotychczasowymi autorami (Include)
            var entity = await _dbContext.Books
                .Include(x => x.Authors)
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (entity == null) return false;

            // Mapujemy podstawowe pola (Tytuł, Status, PublisherId)
            _mapper.Map(dto, entity);

            // Aktualizujemy relację wiele-do-wielu:
            entity.Authors.Clear(); // Czyszczenie starych powiązań
            if (dto.AuthorIds != null && dto.AuthorIds.Any())
            {
                var authors = await _dbContext.Authors
                    .Where(a => dto.AuthorIds.Contains(a.Id))
                    .ToListAsync();

                entity.Authors = authors;
            }

            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
