// Plik: SchoolRegister.Services/Interfaces/IGroupService.cs
using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SchoolRegister.Services.Interfaces
{
    public interface IGroupService
    {
        GroupVm AddOrUpdateGroup(AddOrUpdateGroupVm addOrUpdateGroupVm);
        StudentVm AttachStudentToGroup(AttachDetachStudentToGroupVm vm);
        StudentVm DetachStudentFromGroup(AttachDetachStudentToGroupVm vm);
        SubjectVm AttachSubjectToGroup(AttachDetachSubjectToGroupVm vm);
        SubjectVm DetachSubjectFromGroup(AttachDetachSubjectToGroupVm vm);
        SubjectVm AttachTeacherToSubject(AttachDetachTeacherToSubjectVm vm); // Zgodnie z diagramem
        SubjectVm DetachTeacherFromSubject(AttachDetachTeacherToSubjectVm vm); // Zgodnie z diagramem
        GroupVm GetGroup(Expression<Func<Group, bool>> filterPredicate);
        IEnumerable<GroupVm> GetGroups(Expression<Func<Group, bool>>? filterPredicate = null); // '?' dla nullable
    }
}