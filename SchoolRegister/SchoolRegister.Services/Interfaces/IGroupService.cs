using System.Linq.Expressions;
using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.Interfaces
{
public interface IGroupService
{
    GroupVm AddOrUpdateGroup(AddOrUpdateGroupVm addOrUpgradeGroupVm);
    StudentVm AttachStudentToGroup(AttachDetachStudentToGroupVm attachDetachStudentToGroupVm);
    GroupVm AttachSubjectToGroup(AttachDetachSubjectToGroupVm attachDetachSubjectToGroupVm);
    SubjectVm AttachTeacherToSubject(AttachDetachSubjectToTeacherVm attachDetachSubjectToTeacherVm);
    StudentVm DetachStudentFromGroup(AttachDetachStudentToGroupVm attachDetachStudentToGroupVm);
    GroupVm DetachSubjectFromGroup(AttachDetachSubjectToGroupVm attachDetachSubjectToGroupVm);
    SubjectVm DetachTeacherFromSubject(AttachDetachSubjectToTeacherVm attachDetachSubjectToTeacherVm);
    GroupVm GetGroup(Expression<Func<Group,bool>> filterPredicate);
    IEnumerable<GroupVm> GetGroups(Expression<Func<Group,bool>> filterPredicate =null);

}
}