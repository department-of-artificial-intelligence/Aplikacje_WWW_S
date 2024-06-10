using System.Linq.Expressions;
using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.Interfaces;

public interface IStudentService
{
  public StudentVm GetStudent(Expression<Func<Student, bool>> filterPredicate);
  public IEnumerable<Student> GetStudents(Expression<Func<Student, bool>> filterPredicate = null);
}