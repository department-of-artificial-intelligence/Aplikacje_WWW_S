using System.Linq.Expressions;
using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.Interfaces
{

    public interface IGroupService
    {
        public GroupVm AddOrUpdateGroup(AddOrUpdateGroupVm addOrUpdateGroupVm);
        public StudentVm AttachStudentToGroup(AttachDetachStudentToGroupVm attachDetachStudentToGroupVm);

        public GroupVm AttachSubjectToGroup(AttachDetachSubjectGroupVm attachDetachSubjectGroupVm);

        public SubjectVm AttachTeacherToSubject(AttachDetachSubjectToTeacherVm attachDetachSubjectToTeacherVm);

        public StudentVm DetachStudentFromGroup(AttachDetachStudentToGroupVm attachDetachStudentToGroupVm);

        public GroupVm DetachSubjectFromGroup(AttachDetachSubjectGroupVm attachDetachSubjectGroupVm);

        public SubjectVm DetachTeacherFromSubject(AttachDetachSubjectToTeacherVm attachDetachSubjectToTeacherVm);

        public GroupVm GetGroup(Expression<Func<Group, bool>> filterExpression);

        public IEnumerable<GroupVm> GetGroups(Expression<Func<Group, bool>> filterExpression = null);

    }
}