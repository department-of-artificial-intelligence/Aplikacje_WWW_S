using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Kolokwium.DAL;
using Kolokwium.Services.DTO.Order;
using Kolokwium.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AutoMapper.QueryableExtensions;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.DTO.Meal;


namespace Kolokwium.Services.ConcreteServices
{
    public class OrderService : BaseService, IOrderService
    {
        public OrderService(
            ApplicationDbContext dbContext,
            IMapper mapper,
            ILogger<OrderService> logger) : base(dbContext,mapper,logger){}

        public async Task<List<OrderDto>> GetAllAsync()
        {
            return await DbContext.Orders
                .AsNoTracking()
                .OrderBy(x=> x.OrderDate)
                .ProjectTo<OrderDto>(Mapper.ConfigurationProvider)
                .ToListAsync();


        }
        public async Task<OrderDto?> GetByIdAsync(int id)
        {
            return await DbContext.Orders
                .AsNoTracking()
                .Where(o=> o.Id == id)
                .ProjectTo<OrderDto>(Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<int>CreateAsync(CreateOrderDto dto)
        {
            var entity = Mapper.Map<Order>(dto);

            if(dto.MealIds?.Any() == true)
            {
                entity.Meals = await DbContext.Meals
                .Where(m => dto.MealIds.Contains(m.Id))
                .ToListAsync();
            }

            DbContext.Orders.Add(entity);
            await DbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<List<MealDto>>GetMealsAsync()
        {
             return await DbContext.Meals
                .AsNoTracking()
                .OrderBy(x=> x.Price)
                .ProjectTo<MealDto>(Mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool>DeleteAsync(int id)
        {
            var entity = await DbContext.Orders.FirstOrDefaultAsync(x=>x.Id == id);
            if( entity == null) return false;

            DbContext.Orders.Remove(entity);
            await DbContext.SaveChangesAsync();
            return true;

        }


    }
}