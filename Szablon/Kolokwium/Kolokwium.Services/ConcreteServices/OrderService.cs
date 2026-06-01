using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kolokwium.DAL;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.DTO;
using Kolokwium.Services.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions; // Wymagane dla ProjectTo!
using Microsoft.Extensions.Logging;

namespace Kolokwium.Services.ConcreteServices
{
    public class OrderService : BaseService, IOrderService
    {
        public OrderService(
            ApplicationDbContext dbContext,
            IMapper mapper,
            ILogger<OrderService> logger) : base(dbContext, mapper, logger)
            {}
        
        public async Task<List<OrderDto>> GetAllAsync()
        {
            return await DbContext.Orders
            .AsNoTracking()
            .Include(x => x.DeliveryAddress)
            .OrderBy(x => x.OrderDate)
            .ProjectTo<OrderDto>(Mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<OrderDto?> GetByIdAsync(int id)
        {
            return await DbContext.Orders
            .AsNoTracking()
            .Include(x => x.DeliveryAddress)
            .Where(p => p.Id == id)
            .ProjectTo<OrderDto>(Mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
        }

        public async Task<List<MealDto>> GetMealsAsync()
        {
            return await DbContext.Meals
            .AsNoTracking()
            .OrderBy(x => x.Description)
            .ProjectTo<MealDto>(Mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<int> CreateAsync(CreateOrderDto dto)
        {
            var entity = Mapper.Map<Order>(dto);


            if (dto.MealIds?.Any() == true)
            {
                entity.Meals = await DbContext.Meals.Where(t => dto.MealIds.Contains(t.Id)).ToListAsync();
            }

            DbContext.Orders.Add(entity);
            await DbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await DbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null ) return false;

            DbContext.Orders.Remove(entity);
            await DbContext.SaveChangesAsync();
            return true;
        }


    }
}