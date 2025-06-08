using Kolokwium.Model.DataModels;
using Kolokwium.ViewModel.VM;

namespace Kolokwium.Services.Interfaces;

public interface IBookService
{
    public IList<BookVm> ViewAll();
    public BookVm Add(Book book);
    public BookVm Delete(int Id);
    public BookVm Update(int id);
}