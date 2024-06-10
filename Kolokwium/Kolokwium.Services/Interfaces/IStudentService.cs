using System.Linq.Expressions;
using Kolokwium.Model.DataModels;
using Kolokwium.ViewModel.VM;

namespace Kolokwium.Services.Interfaces; 

public interface IStudentService {
    StudentVm GetStudent(Expression<Func<Student,bool>> predicate); 
    IEnumerable<StudentVm> GetStudents(Expression<Func<Student,bool>>? predicate = null);

    StudentVm AddOrUpdateStudent(AddOrUpdateStudentVm addOrUpdateStudentVm);  

    void DeleteStudent(int id); 

}