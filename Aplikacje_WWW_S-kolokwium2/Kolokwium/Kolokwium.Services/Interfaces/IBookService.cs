using Kolokwium.ViewModel.VM;
using System.Linq.Expressions;

namespace Kolokwium.Services.Interfaces;

public interface IBookService
{
    IEnumerable<BookVm> GetBooks(Expression<Func<Book, bool>>? filter = null);
}

// This interface defines a contract for book services, allowing retrieval of books with optional filtering.
// The GetBooks method returns an enumerable collection of BookVm objects, which are view models representing books.
// DODALEM WSZYSTKIE USINGI I NAMESPACE