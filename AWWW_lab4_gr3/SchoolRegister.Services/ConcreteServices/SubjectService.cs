using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces; 
using SchoolRegister.ViewModels.VM;
 

namespace SchoolRegister.Services.ConcreteServices // Upewnij się, że namespace jest poprawny
{
    public class SubjectService : BaseService, ISubjectService
    {
         
        public SubjectService(ApplicationDbContext dbContext, IMapper mapper, ILogger<SubjectService> logger) // Zmiana na ILogger<SubjectService>
                         : base(dbContext, mapper, logger) { }

        public SubjectVm AddOrUpdateSubject(AddOrUpdateSubjectVm addOrUpdateVm)
        {
            try
            {
                if (addOrUpdateVm == null)
                {
                     
                    throw new ArgumentNullException(nameof(addOrUpdateVm), "View model parameter is null"); // Zmieniono na nameof i dodano drugi parametr dla lepszego komunikatu
                }

                // Krok 1: Mapowanie z ViewModelu (addOrUpdateVm) na encję (Subject).
                // Na tym etapie tworzona jest NOWA instancja subjectEntity, nawet jeśli to aktualizacja.
                var subjectEntity = Mapper.Map<Subject>(addOrUpdateVm);

                if (!addOrUpdateVm.Id.HasValue || addOrUpdateVm.Id == 0)
                {
                    // Krok 2a: Jeśli Id nie ma wartości lub jest 0, traktujemy to jako DODAWANIE nowego przedmiotu.
                    // Encja jest dodawana do DbContext w stanie 'Added'.
                    DbContext.Subjects.Add(subjectEntity);
                     
                }
                else
                {
                    // Krok 2b: Jeśli Id ma wartość, traktujemy to jako AKTUALIZACJĘ istniejącego przedmiotu.
                    // WAŻNE: DbContext.Subjects.Update(subjectEntity) oznacza całą encję jako 'Modified'.
                    // Oznacza to, że EF Core wygeneruje zapytanie SQL, które zaktualizuje WSZYSTKIE kolumny w tabeli Subjects
                    // dla danego Id, bazując na wartościach z subjectEntity. Nawet jeśli tylko jedna właściwość się zmieniła,
                    // wszystkie zostaną wysłane w UPDATE.
                    // subjectEntity tutaj to obiekt stworzony przez AutoMapper z addOrUpdateVm. Jeśli addOrUpdateVm.Id pasuje do
                    // istniejącego rekordu w bazie, EF Core potraktuje to jako aktualizację tego rekordu.
                    DbContext.Subjects.Update(subjectEntity);
                    // Logger.LogInformation($"Aktualizowanie przedmiotu o Id: {subjectEntity.Id}");
                }

                // Krok 3: Zapisanie zmian do bazy danych.
                 
                DbContext.SaveChanges();

                // Krok 4: Mapowanie zapisanej/zaktualizowanej encji (subjectEntity) z powrotem na SubjectVm.
                 
                var subjectVm = Mapper.Map<SubjectVm>(subjectEntity);
                return subjectVm;
            }
            catch (Exception ex)
            {
                // Logowanie wyjątku jest kluczowe dla diagnozowania problemów.
                Logger.LogError(ex, $"Błąd w AddOrUpdateSubject: {ex.Message}"); // Przekazanie samego ex jako pierwszego argumentu do Loggera
                throw;  
            }
        }

        public SubjectVm GetSubject(Expression<Func<Subject, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                {
                    // Logger.LogError("Wywołano GetSubject z filterExpression o wartości null.");
                    throw new ArgumentNullException(nameof(filterExpression), "FilterExpression is null");
                }

                // Krok 1: Pobranie encji z bazy danych.
                // FirstOrDefault wykonuje zapytanie do bazy i zwraca pierwszą pasującą encję lub null.
                var subjectEntity = DbContext.Subjects.FirstOrDefault(filterExpression);

                // Krok 2: Mapowanie pobranej encji (lub null) na SubjectVm.
                // Jeśli subjectEntity jest null, Mapper.Map<SubjectVm>(null) również zwróci null.
                 
                var subjectVm = Mapper.Map<SubjectVm>(subjectEntity);
                return subjectVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Błąd w GetSubject: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<SubjectVm> GetSubjects(Expression<Func<Subject, bool>>? filterExpression = null)
        {
            try
            {
                // Krok 1: Uzyskanie IQueryable<Subject> z DbContext.
                // Na tym etapie żadne zapytanie do bazy danych nie jest jeszcze wykonywane.
                var subjectEntitiesQuery = DbContext.Subjects.AsQueryable();  

                if (filterExpression != null)
                {
                    // Krok 2: Jeśli filtr jest podany, dodajemy warunek WHERE do zapytania.
                    // Nadal żadne zapytanie do bazy nie jest wykonywane.
                    subjectEntitiesQuery = subjectEntitiesQuery.Where(filterExpression);
                }

                
                var subjectVms = Mapper.Map<IEnumerable<SubjectVm>>(subjectEntitiesQuery.ToList());  
                return subjectVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Błąd w GetSubjects: {ex.Message}");
                throw;
            }
        }
    }
}