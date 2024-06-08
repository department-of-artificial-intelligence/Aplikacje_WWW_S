using System.Linq.Expressions;
using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.Interfaces; 

public interface ISubjectService {
    SubjectVm AddOrUpdateSubject(AddOrUpdateSubjectVm addOrUpdateSubjectVm); 
    SubjectVm GetSubject(Expression<Func<Subject, bool>> fitlerExpression);   
    IEnumerable<SubjectVm> GetSubjects(Expression<Func<Subject, bool>> filterExpression = null); 
    
}