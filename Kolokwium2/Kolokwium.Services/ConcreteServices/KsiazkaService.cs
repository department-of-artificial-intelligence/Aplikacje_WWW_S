using AutoMapper;
using Kolokwium.DAL;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.Interfaces;
using Kolokwium.ViewModel.VM;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Kolokwium.Services.ConcreteServices
{
    public class KsiazkaService : BaseService, IKsiazkaService
    {
        public KsiazkaService(ApplicationDbContext dbContext, IMapper mapper, ILogger<KsiazkaService> logger)
            : base(dbContext, mapper, logger)
        {
        }

        public IEnumerable<KsiazkiVm> GetKsiazki(Expression<Func<KsiazkiVm, bool>>? filter = null)
        {
            var ksiazki = DbContext.Ksiazki.ToList();
            var ksiazkiVm = Mapper.Map<List<KsiazkiVm>>(ksiazki);

            if (filter != null)
            {
                return ksiazkiVm.AsQueryable().Where(filter).ToList();
            }
            return ksiazkiVm;
        }

        public KsiazkiVm AddKsiazka(AddKsiazkaVm addKsiazkaVm)
        {
            var ksiazka = Mapper.Map<Ksiazka>(addKsiazkaVm);
            DbContext.Ksiazki.Add(ksiazka);
            DbContext.SaveChanges();
            return Mapper.Map<KsiazkiVm>(ksiazka);
        }

        public KsiazkiVm DeleteKsiazka(int id)
        {
            var ksiazka = DbContext.Ksiazki.FirstOrDefault(k => k.Id == id);
            if (ksiazka == null)
                throw new Exception("Książka nie istnieje");

            DbContext.Ksiazki.Remove(ksiazka);
            DbContext.SaveChanges();
            return Mapper.Map<KsiazkiVm>(ksiazka);
        }
    }
}