using System.Linq.Expressions;
using SchoolRegister.ViewModels.VM;
using SchoolRegister.Model.DataModels;

namespace SchoolRegister.Services.Interfaces
{
  public interface ITeacherService
  {
    TeacherVM GetTeacher(Expression<Func<Teacher, bool>> filterPredicate);
    IEnumerable<TeacherVM> GetTeachers(Expression<Func<Teacher, bool>> filterPredicate = null);

    IEnumerable<GroupVm> GetTeachersGroups(TeachersGroupsVm getTeachersGroups);
  }
}