using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Servicies.Interfaces;
using SchoolRegister.ViewModels.VM;
using System.Linq.Expressions;

namespace SchoolRegister.Servicies.ConcreteServicies
{
    public class TeacherService : BaseService, ITeacherService
    {
        private readonly UserManager<User> _userManager;
        public TeacherService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger, UserManager<User> userManager)
            : base(dbContext, mapper, logger)
        {
            _userManager = userManager;
        }

        public TeacherVm GetTeacher(Expression<Func<Teacher, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentNullException($" FilterExpression is null");


                var entity = DbContext.Users
                           .OfType<Teacher>()
                           .FirstOrDefault(filterExpression);

                var subjectVm = Mapper.Map<TeacherVm>(entity);
                return subjectVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<TeacherVm> GetTeachers(Expression<Func<Teacher, bool>>? filterExpression = null)
        {
            try
            {
                var entities = DbContext.Users
                    .OfType<Teacher>().AsQueryable();

                if (filterExpression != null)
                    entities = entities.Where(filterExpression);
                var entityVms = Mapper.Map<IEnumerable<TeacherVm>>(entities);
                return entityVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<GroupVm> GetTeachersGroups(TeachersGroupsVm getTeacherGroups)
        {
            try
            {
                var entities = DbContext.Groups
                    .Where(sg => sg.SubjectGroups.Any(
                        a => a.Subject.Teacher.Id == getTeacherGroups.TeacherId
                     )
                    );

                var entityVms = Mapper.Map<IEnumerable<GroupVm>>(entities);
                return entityVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
