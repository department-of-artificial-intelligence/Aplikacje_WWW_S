using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
namespace SchoolRegister.Services.ConcreteServices
{
    public class GroupService : BaseService, IGroupService
    {
        public GroupService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
        {
        }

        public GroupVm AddOrUpdateGroup(AddOrUpdateGroupVm addOrUpgradeGroupVm)
        {
            throw new NotImplementedException();
        }

        public StudentVm AttachStudentToGroup(AttachDetachStudentToGroupVm attachDetachStudentToGroupVm)
        {
            throw new NotImplementedException();
        }

        public GroupVm AttachSubjectToGroup(AttachDetachSubjectToGroupVm attachDetachSubjectToGroupVm)
        {
            throw new NotImplementedException();
        }

        public SubjectVm AttachTeacherToSubject(AttachDetachSubjectToTeacherVm attachDetachSubjectToTeacherVm)
        {
            throw new NotImplementedException();
        }

        public StudentVm DetachStudentFromGroup(AttachDetachStudentToGroupVm attachDetachStudentToGroupVm)
        {
            throw new NotImplementedException();
        }

        public GroupVm DetachSubjectFromGroup(AttachDetachSubjectToGroupVm attachDetachSubjectToGroupVm)
        {
            throw new NotImplementedException();
        }

        public SubjectVm DetachTeacherFromSubject(AttachDetachSubjectToTeacherVm attachDetachSubjectToTeacherVm)
        {
            throw new NotImplementedException();
        }

        public GroupVm GetGroup(Expression<Func<Group, bool>> filterPredicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GroupVm> GetGroups(Expression<Func<Group, bool>> filterPredicate = null)
        {
            throw new NotImplementedException();
        }
    }
}