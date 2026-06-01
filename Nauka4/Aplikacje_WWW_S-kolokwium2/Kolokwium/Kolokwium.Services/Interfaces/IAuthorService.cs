using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kolokwium.Services.DTO.Author;

namespace Kolokwium.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<List<AuthorDto>> GetAllAsync();

        Task<AuthorDetailsDto?> GetByIdAsync(int id);

        Task<int> CreateAsync(CreateAuthorDto dto);

        Task<bool> UpdateAsync(UpdateAuthorDto dto);


    }
}
