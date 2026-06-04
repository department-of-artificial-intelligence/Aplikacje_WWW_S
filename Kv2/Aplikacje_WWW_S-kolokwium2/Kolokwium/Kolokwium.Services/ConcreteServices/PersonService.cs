using AutoMapper;
using Kolokwium.DAL;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.DTO;
using Kolokwium.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Services.ConcreteServices
{
    public class PersonService : BaseService, IPersonService
    {
        public PersonService(ApplicationDbContext dbContext, IMapper mapper, ILogger<PersonService> logger)
            : base(dbContext, mapper, logger)
        {
        }

        public async Task<IEnumerable<PersonDto>> GetAllAsync()
        {
            var people = await DbContext.People.ToListAsync();
            return Mapper.Map<IEnumerable<PersonDto>>(people);
        }

        public async Task<PersonDto?> GetByIdAsync(int id)
        {
            var person = await DbContext.People.FindAsync(id);
            return Mapper.Map<PersonDto>(person);
        }

        public async Task CreateAsync(CreatePersonDto dto)
        {
            var person = Mapper.Map<Person>(dto);
            DbContext.People.Add(person);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdatePersonDto dto)
        {
            var existingPerson = await DbContext.People.FindAsync(dto.Id);
            if (existingPerson != null)
            {
                // AutoMapper przepisuje wartości z dto do istniejącej encji śledzonej przez EF
                Mapper.Map(dto, existingPerson);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var person = await DbContext.People.FindAsync(id);
            if (person != null)
            {
                DbContext.People.Remove(person);
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
