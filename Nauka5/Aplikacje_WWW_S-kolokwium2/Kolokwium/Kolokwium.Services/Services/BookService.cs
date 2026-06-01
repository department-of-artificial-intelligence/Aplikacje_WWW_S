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

            public async Task<List<Author>> GetAllAuthorsAsync()
            {
                return await _dbContext.Authors
                    .AsNoTracking()
                    .OrderBy(x => x.FullName)
                    //.ProjectTo<Author>(_mapper.ConfigurationProvider) Tego nie bo to sluzy do mapowania obiektow z dto na inne
                    .ToListAsync();
            }

                public async Task<List<Publisher>> GetAllPublishersAsync()
                {
                    // Pobieramy czyste encje prosto z bazy, bez żadnych DTO!
                    return await _dbContext.Publishers
                        .AsNoTracking()
                        .OrderBy(p => p.Name)
                        .ToListAsync();
                }


        /*Dla 1 do 1
         public async Task<bool> UpdateAsync(UpdateBookDto dto)
             {
                 // 1. Pobierasz czystą książkę (bez Include!)
                 var entity = await _dbContext.Books
                     .FirstOrDefaultAsync(x => x.Id == dto.Id);

                 if (entity == null) return false;

                 // 2. AutoMapper SAM przepisuje Title, Status, PublisherId ORAZ AuthorId (nowy klucz 1:1)
                 _mapper.Map(dto, entity);

                 // 3. Po prostu zapisujesz zmiany w bazie
                 await _dbContext.SaveChangesAsync();
                 return true;
             }
        
                     public async Task<int> CreateAsync(CreateBookDto dto)
            {
                // 1. AutoMapper SAM mapuje Title, Status, PublisherId ORAZ AuthorId
                var entity = _mapper.Map<Book>(dto);

                // 2. Od razu dodajesz encję do bazy, bez żadnego szukania autorów!
                _dbContext.Books.Add(entity);
                await _dbContext.SaveChangesAsync();
    
                return entity.Id;
            }*/
    }
}
