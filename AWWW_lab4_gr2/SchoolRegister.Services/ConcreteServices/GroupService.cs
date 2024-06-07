using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.ConcreteServices
{
    public class GroupService : BaseService, IGroupService
    {
        private readonly UserManager<User> _userManager;

        public GroupService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger, UserManager<User> userManager)
            : base(dbContext, mapper, logger)
        {
            _userManager = userManager;
        }
        public GroupVm AddOrUpdateGroup(AddOrUpdateGroupVm addOrUpdateGroupVm)
        {
            try
            {
                if (addOrUpdateGroupVm == null)
                {
                    throw new ArgumentNullException($"AddOrUpdateGroupVm is null");
                }
                var user = _userManager.FindByIdAsync(addOrUpdateGroupVm.UserId.ToString()).Result;
                if (user == null || !_userManager.IsInRoleAsync(user, "Teacher").Result ||
                    !_userManager.IsInRoleAsync(user, "Admin").Result || user is not Teacher)
                {
                    throw new InvalidOperationException($"You are not allowed to add or update group");
                }
                var groupEntity = Mapper.Map<Group>(addOrUpdateGroupVm);
                if (groupEntity.Id == null || groupEntity.Id == 0)
                    DbContext.Groups.Add(groupEntity);
                else
                    DbContext.Groups.Update(groupEntity);
                DbContext.SaveChanges();
                var groupVm = Mapper.Map<GroupVm>(addOrUpdateGroupVm);
                return groupVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public StudentVm AttachStudentToGroup(AttachDetachStudentToGroupVm attachStudentToGroupVm)
        {
            throw new NotImplementedException();
        }

        public GroupVm AttachSubjectToGroupVm(AttachDetachSubjectGroupVm attachSubjectGroupVm)
        {
            throw new NotImplementedException();
        }

        public SubjectVm AttachTeacherToSubject(AttachDetachSubjectToTeacherVm attachSubjectToTeacherVm)
        {
            throw new NotImplementedException();
        }

        public StudentVm DetachStudentToGroup(AttachDetachStudentToGroupVm detachStudentToGroupVm)
        {
            throw new NotImplementedException();
        }

        public GroupVm DetachSubjectToGroupVm(AttachDetachSubjectGroupVm detachSubjectGroupVm)
        {
            throw new NotImplementedException();
        }

        public SubjectVm DetachTeacherToSubject(AttachDetachSubjectToTeacherVm detachSubjectToTeacherVm)
        {
            throw new NotImplementedException();
        }

        public GroupVm GetGroup(Expression<Func<Group, bool>> filterPredicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GroupVm> GetGroups(Expression<Func<Group, bool>>? filterPredicate = null)
        {
            throw new NotImplementedException();
        }
    }
}
