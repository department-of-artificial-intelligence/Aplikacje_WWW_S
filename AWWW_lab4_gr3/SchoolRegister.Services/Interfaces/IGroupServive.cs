using SchoolRegister.ViewModels.VM;
using SchoolRegister.Model.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace SchoolRegister.Services.Interfaces
{
    public interface IGroupService
    {
        GroupVm AddOrUpdateGroup(AddOrUpdateGroupVm addOrUpdateGroupVm);
        StudentVm AttachStudentToGroup(AttachDetachStudentToGroupVm attachDetachStudentToGroupVm);
        GroupVm AttachStudentToGroup(AttachDetachStudentGroupVm attachDetachStudentGroupVm);
        SubjectVm AttachTeacherToSubject(AttachTeacherToSubjectVm attachTeacherToSubjectVm);
        StudentVm DetachStudentFromGroup(AttachDetachStudentToGroupVm detachStudentToGroupVm);
        GroupVm DetachSubjectFromGroup(AttachDetachSubjectGroupVm attachDetachSubjectGroupVm);
        SubjectVm DetachTeacherFromSubject(AttachDetachSubjectToTeacherVm attachDetachSubjectToTeacherVm);
        GroupVm GetGroup(Expression<Func<Group, bool>> fillterPredicate);
        IEnumerable<GroupVm> GetGroup([Expression<Func<Group, bool>> fillterPredicate = null]);
    }
}