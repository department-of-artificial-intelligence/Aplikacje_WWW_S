using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
using Microsoft.AspNetCore.Identity;
namespace SchoolRegister.Services.ConcreteServices
{
    public class GroupService: BaseService, IGroupService
    {
        private readonly UserManager<User> _userManager;
        public GroupService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger, UserManager<User> userManager)
                            :base(dbContext, mapper, logger) {
                                _userManager = userManager;
        }
        
        public GroupVm AddOrUpdateGroup(AddOrUpdateGroupVm addOrUpdateGroupVm)
        {
            throw new NotImplementedException();
        }
        public StudentVm AttachStudentToGroup(AttachDetachStudentToGroupVm attachStudentToGroupVm)
        {
            throw new NotImplementedException();
        }
        public GroupVm AttachSubjectToGroup(AttachDetachSubjectToGroupVm attachSubjectToGroupVm)
        {
            throw new NotImplementedException();
        }
        public SubjectVm AttachTeacherToSubject(AttachDetachSubjectToTeacherVm attachDetachSubjectToTeacherVm)
        {
            throw new NotImplementedException();
        }
        public StudentVm DetachStudentFromGroup(AttachDetachStudentToGroupVm detachStudentToGroupVm)
        {
            throw new NotImplementedException();
        }
        public GroupVm DetachSubjectFromGroup(AttachDetachSubjectToGroupVm detachDetachSubjectToGroupVm)
        {
            throw new NotImplementedException();
        }
        public SubjectVm DetachTeacherFromSubject(AttachDetachSubjectToTeacherVm attachDetachSubjectToTeacherVm)
        {
            throw new NotImplementedException();
        }
        public GroupVm GetGroup(Expression<Func<Group, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentNullException($" FilterExpression is null");
                var groupEntity = DbContext.Groups.FirstOrDefault(filterExpression);
                var groupVm = Mapper.Map<GroupVm>(groupEntity);
                return groupVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public IEnumerable<GroupVm> GetGroups(Expression<Func<Group, bool>> filterExpression = null)
        {
            try
            {
                var groupEntities = DbContext.Groups.AsQueryable();
                if (filterExpression != null)
                    groupEntities = groupEntities.Where(filterExpression);
                var groupVms = Mapper.Map<IEnumerable<GroupVm>>(groupEntities);
                return groupVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}