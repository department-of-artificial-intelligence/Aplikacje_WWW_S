// Plik: SchoolRegister.Services/ConcreteServices/BaseService.cs
using AutoMapper; // Dla IMapper
using Microsoft.Extensions.Logging; // Dla ILogger
using SchoolRegister.DAL.EF; // Dla ApplicationDbContext

namespace SchoolRegister.Services.ConcreteServices
{
    public abstract class BaseService // Klasa abstrakcyjna, bo nie chcemy tworzyć jej instancji bezpośrednio
    {
        protected readonly ApplicationDbContext DbContext; // Dostępny dla klas dziedziczących
        protected readonly IMapper Mapper;               // Dostępny dla klas dziedziczących
        protected readonly ILogger Logger;               // Dostępny dla klas dziedziczących

        // Konstruktor, który przyjmuje wstrzyknięte zależności
        // Klasy dziedziczące będą musiały wywołać ten konstruktor bazowy
        protected BaseService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}