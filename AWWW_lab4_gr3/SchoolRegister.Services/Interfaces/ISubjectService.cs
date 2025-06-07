using SchoolRegister.ViewModels.VM; // Dla SubjectVm i AddOrUpdateSubjectVm
using System;
using System.Collections.Generic;
using System.Linq.Expressions; // Dla Expression<Func<Subject, bool>>

// Uwaga: Instrukcja pokazuje Expression<Func<Subject, bool>> jako typ dla filterExpression.
// Subject to encja. Jeśli chcemy, aby logika filtrowania była całkowicie w warstwie serwisowej
// i nie przeciekała implementacja EF Core (IQueryable) na zewnątrz, to jest to jedno z podejść.
// Alternatywnie, serwisy mogłyby przyjmować bardziej generyczne parametry filtrowania.
using SchoolRegister.Model.DataModels; 

namespace SchoolRegister.Services.Interfaces
{
    public interface ISubjectService
    {
         SubjectVm AddOrUpdateSubject(AddOrUpdateSubjectVm addOrUpdateVm);
        SubjectVm GetSubject(Expression<Func<Subject, bool>> filterExpression);
        IEnumerable<SubjectVm> GetSubjects(Expression<Func<Subject, bool>>? filterExpression = null); 
    }
}