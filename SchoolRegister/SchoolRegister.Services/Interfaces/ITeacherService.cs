using System.Linq.Expressions;
using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.Interfaces
{
public interface ITeacherService
{
    TeacherVm GetTeacher(Expression<Func<Teacher, bool>> filterExpression);
    IEnumerable<TeacherVm> GetSubjects(Expression<Func<Teacher, bool>> filterExpression = null);
    IEnumerable<GroupVm> GetTeachersGroups(TeachersGroupsVm getTeachersGroups);
}
}