using System.Linq.Expressions;
using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM;
namespace SchoolRegister.Services.Interfaces;
public interface IGroupService
{
    GroupVm AddOrUpdateGroup(AddOrUpdateGroupVm addOrUpdateGroupVm);
    Task<StudentVm> AttachStudentToGroup(AttachDetachStudentToGroupVm attachDetachStudentToGroupVm);
    GroupVm AttachSubjectToGroup(AttachDetachSubjectGroupVm attachDetachSubjectGroupVm);
    Task<SubjectVm> AttachTeacherToSubject(AttachDetachSubjectToTeacherVm attachDetachSubjectToTeacherVm);
    Task<StudentVm> DetachStudentFromGroup(AttachDetachStudentToGroupVm attachDetachStudentToGroupVm);
    GroupVm DetachSubjectFromGroup(AttachDetachSubjectGroupVm attachDetachSubjectGroupVm);
    SubjectVm DetachTeacherFromSubject(AttachDetachSubjectToTeacherVm attachDetachSubjectToTeacherVm);
    GroupVm GetGroup(Expression<Func<Group, bool>> filterPredicate);
    IEnumerable<GroupVm> GetGroups(Expression<Func<Group, bool>>? filterPredicate = null);
}