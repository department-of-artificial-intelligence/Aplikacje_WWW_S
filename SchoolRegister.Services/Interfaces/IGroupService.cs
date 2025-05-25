using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.Interfaces
{
    public interface IGroupService
    {
        GroupVm AddOrUpdateGroup(AddOrUpdateGroupVm groupVm);
        GroupVm GetGroup(Expression<Func<Group, bool>> filterExpression);
        IEnumerable<GroupVm> GetGroups(Expression<Func<Group, bool>> filterExpression = null);
        StudentVm AttachStudentToGroup(AttachDetachStudentToGroupVm AttachStudentToGroupVm);
        StudentVm DetachStudentFromGroup(AttachDetachStudentToGroupVm detachStudentToGroupVm);
        GroupVm AttachSubjectToGroup(AttachDetachSubjectGroupVm attachSubjectGroupVm);
        GroupVm DetachSubjectFromGroup(AttachDetachSubjectGroupVm detachDetachSubjectVm);
        SubjectVm AttachTeacherToSubject(AttachDetachSubjectToTeacherVm attachDetachSubjectToTeacherVm);
        SubjectVm DetachTeacherFromSubject(AttachDetachSubjectToTeacherVm attachDetachSubjectToTeacherVm);
    }
}