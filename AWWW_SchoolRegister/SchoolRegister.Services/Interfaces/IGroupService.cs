using System.Linq.Expressions;
using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.Interfaces;

public interface IGroupService
{
  public GroupVm AddOrUpdateGroup(AddOrUpdateGroupVm addOrUpdateGroupVm);
  public StudentVm AttachStudentToGroup(AttachDetachStudentToGroupVm attachDetachStudentToGroupVm);
  public GroupVm AttachSubjectToGroup(AttachDetachSubjectToGroupVm attachDetachSubjectToGroupVm);
  public SubjectVm AttachTeacherToSubject(AttachDetachSubjectToTeacherVm attachDetachSubjectToTeacherVm);

  public StudentVm DetachStudentFromGroup(AttachDetachStudentToGroupVm attachDetachStudentToGroupVm);
  public GroupVm DetachSubjectFromGroup(AttachDetachSubjectToGroupVm attachDetachSubjectToGroupVm);
  public SubjectVm DetachTeacherFromSubject(AttachDetachSubjectToTeacherVm attachDetachSubjectToTeacherVm);

  public GroupVm GetGroup(Expression<Func<Group, bool>> filterPredicate);
  public IEnumerable<GroupVm> GetGroups(Expression<Func<Group, bool>> filterPredicate = null);
}