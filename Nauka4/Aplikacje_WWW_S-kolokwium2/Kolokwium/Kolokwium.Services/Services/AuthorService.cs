using AutoMapper;
using Kolokwium.DAL;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Kolokwium.Services.Interfaces;
using AutoMapper.QueryableExtensions;
using Kolokwium.Services.DTO.Author;
using Kolokwium.Model.DataModels;

namespace Kolokwium.Services.Services
{
    public class AuthorService : BaseService, IAuthorService
    {
        public AuthorService(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
        public async Task<List<AuthorDto>> GetAllAsync()
        {
            return await _dbContext.Authors
                .AsNoTracking()
                .OrderBy(x => x.FullName)
                .ProjectTo<AuthorDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<AuthorDetailsDto?> GetByIdAsync(int id)
        {
            return await _dbContext.Authors
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ProjectTo<AuthorDetailsDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateAuthorDto dto)
        {
            var entity = _mapper.Map<Author>(dto);

            _dbContext.Authors.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateAuthorDto dto)
        {
            var entity = await _dbContext.Authors.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);

            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
