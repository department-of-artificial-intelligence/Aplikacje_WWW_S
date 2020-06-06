using SchoolRegister.BLL.Entities;
using SchoolRegister.ViewModels.DTOs;
using SchoolRegister.ViewModels.VMs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SchoolRegister.Services.Interfaces
{
    public interface IGroupService
    {
        GroupVm AddOrUpdateGroup(AddOrUpdateGroupDto addOrUpdateGroupDto);
        GroupVm GetGroup(Expression<Func<Group, bool>> filterPredicate);
        IEnumerable<GroupVm> GetGroups(Expression<Func<Group, bool>> filterPredicate = null);
        StudentVm AttachStudentToGroup(AttachDetachStudentToGroupDto attachStudentToGroupDto);
        StudentVm DetachStudentFromGroup(AttachDetachStudentToGroupDto detachStudentToGroupDto);
        GroupVm AttachSubjectToGroup(AttachDetachSubjectGroupDto attachSubjectGroup);
        GroupVm DetachSubjectFromGroup(AttachDetachSubjectGroupDto detachDetachSubject);
    }
}
