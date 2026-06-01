using AutoMapper;
using AutoMapper.QueryableExtensions;
using Kolokwium.DAL;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.DTO.Author;
using Kolokwium.Services.DTO.Publisher;
using Kolokwium.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Services.Services
{
    public class PublisherService : BaseService,IPublisherService
    {
        public PublisherService(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
        public async Task<PublisherDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Publishers
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ProjectTo<PublisherDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(PublisherDto dto)
        {
            var entity = _mapper.Map<Publisher>(dto);

            _dbContext.Publishers.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<List<PublisherDto>> GetAllAsync()
        {
            return await _dbContext.Publishers
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .ProjectTo<PublisherDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
