using Kolokwium.ViewModel.VM;
using System.Linq.Expressions;

namespace Kolokwium.Services.Interfaces
{
    public interface IKsiazkaService
    {
        IEnumerable<KsiazkiVm> GetKsiazki(Expression<Func<KsiazkiVm, bool>>? filter = null);
        KsiazkiVm AddKsiazka(AddKsiazkaVm addKsiazkaVm);
        KsiazkiVm DeleteKsiazka(int id);
    }
}