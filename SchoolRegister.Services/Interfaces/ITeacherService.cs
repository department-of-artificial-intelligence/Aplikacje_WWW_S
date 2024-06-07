using System.Linq.Expressions;
using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.Interfaces;
public interface ITeacherService
{
    public TeacherVm GetTeacher(Expression<Func<Teacher, bool>> filterExpression);
    public IEnumerable<TeacherVm> GetTeachers(Expression<Func<Teacher, bool>> filterExpression = null);

    public IEnumerable<GroupVm> GetTeachersGroups(TeachersGroupsVm teachersGroupsVm);
}