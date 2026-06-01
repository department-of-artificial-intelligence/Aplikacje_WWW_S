using Kolokwium.Services.DTO.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllAsync();

        Task<BookDetailsDto?> GetByIdAsync(int id);

        Task<int> CreateAsync(CreateBookDto dto);

        Task<bool> UpdateAsync(UpdateBookDto dto);
    }
}
