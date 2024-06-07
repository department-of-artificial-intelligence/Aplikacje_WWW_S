using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.ConcreteServices;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;

public class GroupService : BaseService, IGroupService
{

    public UserManager<User> _userManager { get; set; }
    public GroupService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger, UserManager<User> userManager) : base(dbContext, mapper, logger)
    {
        _userManager = userManager;
    }

    public GroupVm AddOrUpdateGroup(AddOrUpdateGroupVm addOrUpdateGroupVm)
    {
        try
        {
            if (addOrUpdateGroupVm == null)
                throw new ArgumentNullException($"View model parameter is null");
            var groupEntity = Mapper.Map<Group>(addOrUpdateGroupVm);
            if (addOrUpdateGroupVm.Id == null)
                DbContext.Groups.Add(groupEntity);
            else
                DbContext.Groups.Update(groupEntity);
            DbContext.SaveChanges();
            var groupVm = Mapper.Map<GroupVm>(groupEntity);
            return groupVm;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

    public StudentVm AttachStudentToGroup(AttachDetachStudentToGroupVm attachDetachStudentToGroupVm)
    {
        try
        {
            if (attachDetachStudentToGroupVm == null)
                throw new ArgumentNullException($"View model parameter is null");
            var studentEntity = DbContext.Users.OfType<Student>().FirstOrDefault(s => s.Id == attachDetachStudentToGroupVm.StudentId);
            var groupEntity = DbContext.Groups.FirstOrDefault(g => g.Id == attachDetachStudentToGroupVm.GroupId);
            if (studentEntity == null || groupEntity == null)
                throw new ArgumentNullException($"Student or Group does not exist");
            groupEntity.Students.Add(studentEntity);
            DbContext.SaveChanges();
            var studentVm = Mapper.Map<StudentVm>(studentEntity);
            return studentVm;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

    public GroupVm AttachSubjectToGroup(AttachDetachSubjectGroupVm attachDetachSubjectGroupVm)
    {
        try
        {
            if (attachDetachSubjectGroupVm == null)
                throw new ArgumentNullException($"View model parameter is null");
            var subjectEntity = DbContext.Subjects.FirstOrDefault(s => s.Id == attachDetachSubjectGroupVm.SubjectId);
            var groupEntity = DbContext.Groups.FirstOrDefault(g => g.Id == attachDetachSubjectGroupVm.GroupId);
            if (subjectEntity == null || groupEntity == null)
                throw new ArgumentNullException($"Subject or Group does not exist");
            groupEntity.Subjects.Add(subjectEntity);

            DbContext.SubjectGroups.Add(new SubjectGroup
            {
                GroupId = groupEntity.Id,
                SubjectId = subjectEntity.Id
            });
            DbContext.SaveChanges();

            var groupVm = Mapper.Map<GroupVm>(groupEntity);
            return groupVm;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

    public SubjectVm AttachTeacherToSubject(AttachDetachSubjectToTeacherVm attachDetachSubjectToTeacherVm)
    {
        try
        {
            if (attachDetachSubjectToTeacherVm == null)
                throw new ArgumentNullException($"View model parameter is null");
            var teacherEntity = DbContext.Users.OfType<Teacher>().FirstOrDefault(t => t.Id == attachDetachSubjectToTeacherVm.TeacherId);
            var subjectEntity = DbContext.Subjects.FirstOrDefault(s => s.Id == attachDetachSubjectToTeacherVm.SubjectId);
            if (teacherEntity == null || subjectEntity == null)
                throw new ArgumentNullException($"Teacher or Subject does not exist");
            subjectEntity.Teacher = teacherEntity;
            DbContext.SaveChanges();
            var subjectVm = Mapper.Map<SubjectVm>(subjectEntity);
            return subjectVm;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

    public StudentVm DetachStudentFromGroup(AttachDetachStudentToGroupVm attachDetachStudentToGroupVm)
    {
        try
        {
            if (attachDetachStudentToGroupVm == null)
                throw new ArgumentNullException($"View model parameter is null");
            var studentEntity = DbContext.Users.OfType<Student>().FirstOrDefault(s => s.Id == attachDetachStudentToGroupVm.StudentId);
            var groupEntity = DbContext.Groups.FirstOrDefault(g => g.Id == attachDetachStudentToGroupVm.GroupId);
            if (studentEntity == null || groupEntity == null)
                throw new ArgumentNullException($"Student or Group does not exist");
            studentEntity.GroupId = null;
            DbContext.SaveChanges();
            var studentVm = Mapper.Map<StudentVm>(studentEntity);
            return studentVm;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

    public GroupVm DetachSubjectFromGroup(AttachDetachSubjectGroupVm attachDetachSubjectGroupVm)
    {
        try
        {
            if (attachDetachSubjectGroupVm == null)
                throw new ArgumentNullException($"View model parameter is null");
            var subjectEntity = DbContext.Subjects.FirstOrDefault(s => s.Id == attachDetachSubjectGroupVm.SubjectId);
            var groupEntity = DbContext.Groups.FirstOrDefault(g => g.Id == attachDetachSubjectGroupVm.GroupId);
            if (subjectEntity == null || groupEntity == null)
                throw new ArgumentNullException($"Subject or Group does not exist");
            subjectEntity.SubjectGroups.Remove(subjectEntity.SubjectGroups.FirstOrDefault(sg => sg.GroupId == groupEntity.Id));
            DbContext.SaveChanges();
            var groupVm = Mapper.Map<GroupVm>(groupEntity);
            return groupVm;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

    public SubjectVm DetachTeacherFromSubject(AttachDetachSubjectToTeacherVm attachDetachSubjectToTeacherVm)
    {
        try
        {
            if (attachDetachSubjectToTeacherVm == null)
                throw new ArgumentNullException($"View model parameter is null");
            var teacherEntity = DbContext.Users.OfType<Teacher>().FirstOrDefault(t => t.Id == attachDetachSubjectToTeacherVm.TeacherId);
            var subjectEntity = DbContext.Subjects.FirstOrDefault(s => s.Id == attachDetachSubjectToTeacherVm.SubjectId);
            if (teacherEntity == null || subjectEntity == null)
                throw new ArgumentNullException($"Teacher or Subject does not exist");
            subjectEntity.Teacher = null;
            DbContext.SaveChanges();
            var subjectVm = Mapper.Map<SubjectVm>(subjectEntity);
            return subjectVm;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
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