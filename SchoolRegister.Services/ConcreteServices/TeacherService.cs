using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.ConcreteServices;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;

public class TeacherService : BaseService, ITeacherService
{
    public TeacherService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
    {
    }

    public TeacherVm GetTeacher(Expression<Func<Teacher, bool>> filterExpression)
    {
        try
        {
            if (filterExpression == null)
                throw new ArgumentNullException($" FilterExpression is null");
            var teacherEntity = DbContext.Users
                .OfType<Teacher>()
            .FirstOrDefault(filterExpression);
            var teacherVm = Mapper.Map<TeacherVm>(teacherEntity);
            return teacherVm;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

    public IEnumerable<TeacherVm> GetTeachers(Expression<Func<Teacher, bool>> filterExpression = null)
    {
        try
        {
            var teacherEntities = DbContext.Users
                .OfType<Teacher>()
                .AsQueryable();
            if (filterExpression != null)
                teacherEntities = teacherEntities.Where(filterExpression);
            var teacherVms = Mapper.Map<IEnumerable<TeacherVm>>(teacherEntities);
            return teacherVms;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;

        }
    }

    public IEnumerable<GroupVm> GetTeachersGroups(TeachersGroupsVm teachersGroupsVm)
    {
        try
        {
            if (teachersGroupsVm == null)
                throw new ArgumentNullException($"View model parameter is null");
            var teacherEntity = DbContext.Users
                .OfType<Teacher>()
                .FirstOrDefault(t => t.Id == teachersGroupsVm.TeacherId);
            if (teacherEntity == null)
                throw new ArgumentNullException($"Teacher with id: {teachersGroupsVm.TeacherId} does not exist");
            var groupEntities = DbContext.SubjectGroups.Where(sub => teacherEntity.Subjects.Contains(sub.Subject));

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