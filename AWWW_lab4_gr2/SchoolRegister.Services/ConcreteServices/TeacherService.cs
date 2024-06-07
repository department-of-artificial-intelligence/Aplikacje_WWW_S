using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.Services.ConcreteServices
{
    public class TeacherService : BaseService, ITeacherService
    {
        private readonly UserManager<User> _userManager;

        public TeacherService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger, UserManager<User> userManager) : base(dbContext, mapper, logger)
        {
            _userManager = userManager;
        }

        public TeacherVm GetTeacher(Expression<Func<Teacher, bool>> filterPredicate)
        {
            try
            {
                if (filterPredicate == null)
                    throw new ArgumentNullException($" FilterPredicate is null");
                var teacherEntity = DbContext.Users.OfType<Teacher>().FirstOrDefault(filterPredicate);
                var teacherVm = Mapper.Map<TeacherVm>(teacherEntity);
                return teacherVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<TeacherVm> GetTeachers(Expression<Func<Teacher, bool>>? filterPredicate = null)
        {
            try
            {
                var teacherEntities = DbContext.Users.OfType<Teacher>().AsQueryable();
                if (filterPredicate != null)
                {
                    teacherEntities = teacherEntities.Where(filterPredicate);
                }
                var teacherVms = Mapper.Map<IEnumerable<TeacherVm>>(teacherEntities);
                return teacherVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<GroupVm> GetTeachersGroups(TeachersGroupsVm getTeacherGroup)
        {
            try
            {
                if (getTeacherGroup == null)
                    throw new ArgumentNullException($" TeacherId is null");
                var teacherEntity = DbContext.Users.OfType<Teacher>().FirstOrDefault(t => t.Id == getTeacherGroup.TeacherId);
                var teachersSubjects = teacherEntity!.Subjects?.ToList();
                if (teachersSubjects == null)
                    throw new NullReferenceException($" Teacher's Subjects is null");
                List<Group> groups = new List<Group>();
                foreach (var teacherSubject in teachersSubjects)
                {
                    var teacherSubjectGroups = teacherSubject.SubjectGroups?.ToList();
                    if (teacherSubjectGroups == null)
                        throw new NullReferenceException($" Teacher's Subject Groups is null");
                    foreach (var subjectGroup in teacherSubjectGroups)
                        groups.Add(subjectGroup.Group);
                }
                List<GroupVm> groupsVm = Mapper.Map<List<GroupVm>>(groups);
                return groupsVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
