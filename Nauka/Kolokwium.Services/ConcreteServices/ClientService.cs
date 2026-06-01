using Microsoft.EntityFrameworkCore;
using Kolokwium.DAL;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Logging;
using Kolokwium.Services.DTO.Client;
using Kolokwium.Services.DTO.Order;

namespace Kolokwium.Services.ConcreteServices
{
    public class ClientService : BaseService, IClientService
    {
        public ClientService(
            ApplicationDbContext dbContext,
            IMapper mapper,
            ILogger<ClientService> logger) : base(dbContext, mapper, logger){}
        
        public async Task<List<ClientDto>> GetAllAsync()
        {
            return await DbContext.Clients
            .AsNoTracking()
            .OrderBy(x => x.FirstName)
            .ProjectTo<ClientDto>(Mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<ClientDto?> GetByIdAsync(int id)
        {
            return await DbContext.Clients
            .AsNoTracking()
            .Where(p => p.Id == id)
            .ProjectTo<ClientDto>(Mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
        }

        public async Task<List<OrderDto>> GetOrdersAsync()
        {
            return await DbContext.Orders
            .AsNoTracking()
            .OrderBy(x => x.CreationDate)
            .ProjectTo<OrderDto>(Mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<int> CreateAsync(CreateClientDto dto)
        {
            var entity = Mapper.Map<Client>(dto);

            if(dto.OrderIds?.Any() == true)
            {
                entity.Orders = await DbContext.Orders.Where(t => dto.OrderIds.Contains(t.Id)).ToListAsync();
            }

            DbContext.Clients.Add(entity);
            await DbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await DbContext.Clients
            .Include(c => c.Orders) // Tutaj to
            .FirstOrDefaultAsync(x => x.Id == id);

            if(entity == null) return false;

            // Ta petla wymagana
            foreach(var order in entity.Orders)
            {
                order.ClientId = null;
            }

            DbContext.Clients.Remove(entity);
            await DbContext.SaveChangesAsync();
            return true;
        }
    }
}