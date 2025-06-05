using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Kolokwium.DAL;
using Kolokwium.Services.Interfaces;
using Kolokwium.ViewModel.VM;
using System.Linq.Expressions;

namespace Kolokwium.Services.ConcreteServices;

public class BookService : BaseService, IBookService
{
    public BookService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger)
        : base(dbContext, mapper, logger) { }

    public IEnumerable<BookVm> GetBooks(Expression<Func<Book, bool>>? filter = null)
    {
        var query = DbContext.Books.Include(b => b.Author).AsQueryable();
        if (filter != null)
            query = query.Where(filter);

        return Mapper.Map<IEnumerable<BookVm>>(query);
    }
}


// This class implements the IBookService interface, providing functionality to retrieve books from the database.
// It uses Entity Framework Core to query the Books table, including related Author data.

//TU WSZYSTKO TRZEBA NAPISAC SAMEMU