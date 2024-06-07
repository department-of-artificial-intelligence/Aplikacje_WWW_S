using System.Linq.Expressions;
using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM;

public interface IStudentService
{
    public StudentVm GetStudent(Expression<Func<Student, bool>> filterExpression);
    public IEnumerable<StudentVm> GetStudents(Expression<Func<Student, bool>> filterExpression = null);

}