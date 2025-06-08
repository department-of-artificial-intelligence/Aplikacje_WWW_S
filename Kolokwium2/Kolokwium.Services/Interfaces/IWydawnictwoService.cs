using Kolokwium.Model.DataModels;
using Kolokwium.ViewModel.VM;
using System.Collections.Generic;

namespace Kolokwium.Services.Interfaces
{
    public interface IWydawnictwoService
    {
        IEnumerable<WydawnictwoVm> GetAll();
        WydawnictwoVm GetById(int id);
    }
}