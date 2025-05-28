using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.Interfaces
{
    public interface IGroupService
    {
        //GroupVm AddOrUpdateGroup(AddOrUpdateGroupVm groupVm);
        bool DeleteGroup(int groupId);
        GroupVm GetGroup(int groupId);
        IEnumerable<GroupVm> GetGroups(Expression<Func<Group, bool>> filter = null);
        IEnumerable<StudentVm> GetStudentsInGroup(int groupId);
        IEnumerable<TeacherVm> GetTeachersInGroup(int groupId);
    }
}