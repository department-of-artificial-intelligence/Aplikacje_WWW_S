using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kolokwium.DAL;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.DTO.Product;
using Kolokwium.Services.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions; // Wymagane dla ProjectTo!
using Microsoft.Extensions.Logging;

namespace Kolokwium.Services.ConcreteServices
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(
            ApplicationDbContext dbContext, 
            IMapper mapper, 
            ILogger<ProductService> logger) : base(dbContext, mapper, logger)
        {
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            // AutoMapper w metodzie ProjectTo sam domyśla się, że musi wykonać JOIN (Include) 
            // do tabeli Category i Tags na podstawie konfiguracji profilu!
            return await DbContext.Products
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .ProjectTo<ProductDto>(Mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            return await DbContext.Products
                .AsNoTracking()
                .Where(p => p.Id == id)
                .ProjectTo<ProductDto>(Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateProductDto dto)
{
    // 1. AutoMapper zamienia DTO na Encję
    var entity = Mapper.Map<Product>(dto);

    // --- KLUCZOWA LINIJKA DO DODANIA ---
    // Odcinamy pusty obiekt, zmuszając EF Core do użycia tylko samego CategoryId
    entity.Category = null; 
    // -----------------------------------

    if (dto.TagIds != null && dto.TagIds.Any())
    {
        var tags = await DbContext.Tags.Where(t => dto.TagIds.Contains(t.Id)).ToListAsync();
        entity.Tags = tags;
    }

    DbContext.Products.Add(entity);
    await DbContext.SaveChangesAsync();
    
    return entity.Id;
}

        public async Task<bool> UpdateAsync(UpdateProductDto dto)
        {
            var entity = await DbContext.Products
                .Include(p => p.Tags)
                .FirstOrDefaultAsync(x => x.Id == dto.Id);
                
            if (entity == null)
            {
                Logger.LogWarning($"Nie znaleziono produktu o ID: {dto.Id}.");
                return false;
            }

            // Magia AutoMappera: nadpisuje właściwości encji wartościami z DTO
            Mapper.Map(dto, entity);

            // Aktualizacja tagów
            entity.Tags.Clear();
            if (dto.TagIds != null && dto.TagIds.Any())
            {
                var newTags = await DbContext.Tags.Where(t => dto.TagIds.Contains(t.Id)).ToListAsync();
                foreach (var tag in newTags)
                {
                    entity.Tags.Add(tag);
                }
            }

            await DbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await DbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) return false;

            DbContext.Products.Remove(entity);
            await DbContext.SaveChangesAsync();
            return true;
        }
    }
}