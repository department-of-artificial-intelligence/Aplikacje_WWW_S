using AutoMapper;
using Kolokwium.DAL;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.Interfaces;
using Kolokwium.ViewModel.VM;
using Microsoft.Extensions.Logging;

namespace Kolokwium.Services.ConcreteServices
{
    public class WydawnictwoService : BaseService, IWydawnictwoService
    {
        public WydawnictwoService(ApplicationDbContext dbContext, IMapper mapper, ILogger<WydawnictwoService> logger)
            : base(dbContext, mapper, logger)
        {
        }

        public IEnumerable<WydawnictwoVm> GetAll()
        {
            var wydawnictwa = DbContext.Set<Wydawnictwo>().ToList();
            return Mapper.Map<List<WydawnictwoVm>>(wydawnictwa);
        }

        public WydawnictwoVm GetById(int id)
        {
            var wydawnictwo = DbContext.Set<Wydawnictwo>().FirstOrDefault(w => w.Id == id);
            return Mapper.Map<WydawnictwoVm>(wydawnictwo);
        }
    }
}