using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.Interfaces
{
    public interface ITeacherService
    {
        TeacherVm AddOrUpdateTeacher(AddOrUpdateTeacherVm TeacherVm);
        TeacherVm GetTeacher(Expression<Func<Teacher, bool>> filterExpression);
        IEnumerable<TeacherVm> GetTeachers(Expression<Func<Teacher, bool>> filterExpression = null);
        IEnumerable<GroupVm> GetTeachersGroups(TeachersGroupsVm getTeachersGroup);
    }
}