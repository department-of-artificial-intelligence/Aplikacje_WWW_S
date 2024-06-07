using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.Interfaces
{
    public interface IGroupService
    {
        public GroupVm AddOrUpdateGroup(AddOrUpdateGroupVm addOrUpdateGroupVm);
        public StudentVm AttachStudentToGroup(AttachDetachStudentToGroupVm attachStudentToGroupVm);
        public GroupVm AttachSubjectToGroupVm(AttachDetachSubjectGroupVm attachSubjectGroupVm);
        public SubjectVm AttachTeacherToSubject(AttachDetachSubjectToTeacherVm attachSubjectToTeacherVm);
        public StudentVm DetachStudentToGroup(AttachDetachStudentToGroupVm detachStudentToGroupVm);
        public GroupVm DetachSubjectToGroupVm(AttachDetachSubjectGroupVm detachSubjectGroupVm);
        public SubjectVm DetachTeacherToSubject(AttachDetachSubjectToTeacherVm detachSubjectToTeacherVm);
        public GroupVm GetGroup(Expression<Func<Group, bool>> filterPredicate);
        public IEnumerable<GroupVm> GetGroups(Expression<Func<Group, bool>>? filterPredicate = null);
    }
}
