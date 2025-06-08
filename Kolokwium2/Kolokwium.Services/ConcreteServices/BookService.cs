using AutoMapper;
using Kolokwium.DAL;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.Interfaces;
using Kolokwium.ViewModel.VM;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Kolokwium.Services.ConcreteServices;

public class BookService : BaseService, IBookService
{
    public BookService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
    {
    }

    public BookVm Add(Book book)
    {
        var add = Mapper.Map<Book>(book);
        DbContext.Add(add);
        DbContext.SaveChanges();
        return Mapper.Map<BookVm>(add);
    }
    public BookVm Update(int id)
    {
        var update = DbContext.Books.FirstOrDefault(b => b.Id == id);
        if (update != null)
        {
            DbContext.Update(update);
            DbContext.SaveChanges();
        }
        return Mapper.Map<BookVm>(update);
    }

    public BookVm Delete(int Id)
    {
        var delete = DbContext.Books.FirstOrDefault(b => b.Id == Id);
        DbContext.Books.Remove(delete);
        DbContext.SaveChanges();
        return Mapper.Map<BookVm>(delete);
    }

    public IList<BookVm> ViewAll()
    {
        var view = DbContext.Books.Include(b => b.Author).Include(a => a.libraries).ToList();
        return Mapper.Map<IList<BookVm>>(view);
    }
}