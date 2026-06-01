using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kolokwium.Services.DTO.Publisher;

namespace Kolokwium.Services.Interfaces
{
    public interface IPublisherService
    {

        Task<PublisherDto?> GetByIdAsync(int id);

        Task<List<PublisherDto>> GetAllAsync();

        //Jakby bylo tez wiele do wielu
        // Task<List<PublisherDto>> GetByBookIdsAsync(int bookId); // Zmiana z jednego obiektu na List<>
        Task<int> CreateAsync(PublisherDto dto);

    }
}
