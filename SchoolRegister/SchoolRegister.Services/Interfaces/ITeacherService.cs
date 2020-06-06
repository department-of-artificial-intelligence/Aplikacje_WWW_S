using SchoolRegister.BLL.Entities;
using SchoolRegister.ViewModels.DTOs;
using SchoolRegister.ViewModels.VMs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SchoolRegister.Services.Interfaces
{

    public interface ITeacherService
    {
        bool SendEmailToParent(SendEmailToParentDto sendEmailToParentDto);

        IEnumerable<TeacherVm> GetTeachers(Expression<Func<Teacher, bool>> filterPredicate = null);
        TeacherVm GetTeacher(Expression<Func<Teacher, bool>> filterPredicate);
        IEnumerable<GroupVm> GetTeachersGroups(GetTeachersGroupsDto getTeachersGroups);

    }
}