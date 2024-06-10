using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.ConcreteServices;

public class GroupService : BaseService, IGroupService
{
  public GroupService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger, UserManager<User> manager) : base(dbContext, mapper, logger, manager)
  {
  }

  public GroupVm AddOrUpdateGroup(AddOrUpdateGroupVm addOrUpdateGroupVm)
  {
    try
    {
      var group = Mapper.Map<Group>(addOrUpdateGroupVm);

      if (!addOrUpdateGroupVm.Id.HasValue || addOrUpdateGroupVm.Id == 0)
        DbContext.Groups.Add(group);
      else
        DbContext.Groups.Update(group);

      DbContext.SaveChanges();

      var groupVm = Mapper.Map<GroupVm>(group);
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
      var student = DbContext.Users.OfType<Student>().FirstOrDefault(s => s.Id == attachDetachStudentToGroupVm.StudentId);
      if (!student.GroupId.HasValue || student.GroupId != attachDetachStudentToGroupVm.GroupId)
        student.GroupId = attachDetachStudentToGroupVm.GroupId;
      else if (student.GroupId == attachDetachStudentToGroupVm.GroupId)
        student.GroupId = attachDetachStudentToGroupVm.GroupId;
      else
        throw new Exception("Problem");
      DbContext.Update(student);
      DbContext.SaveChanges();

      var studentVm = Mapper.Map<StudentVm>(student);
      return studentVm;
    }
    catch (Exception ex)
    {
      Logger.LogError(ex, ex.Message);
      throw;
    }
  }

  public GroupVm AttachSubjectToGroup(AttachDetachSubjectToGroupVm attachDetachSubjectToGroupVm)
  {
    try
    {
      var subjectGroup = new SubjectGroup
      {
        SubjectId = attachDetachSubjectToGroupVm.SubjectId,
        GroupId = attachDetachSubjectToGroupVm.GroupId,
      };

      DbContext.SubjectGroups.Add(subjectGroup);
      DbContext.SaveChanges();


      var group = DbContext.Groups.FirstOrDefault(g => g.Id == attachDetachSubjectToGroupVm.GroupId);
      var groupVm = Mapper.Map<GroupVm>(group);

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
      var subject = DbContext.Subjects.FirstOrDefault(s => s.Id == attachDetachSubjectToTeacherVm.SubjectId);

      subject.TeacherId = attachDetachSubjectToTeacherVm.TeacherId;
      DbContext.Update(subject);
      DbContext.SaveChanges();

      var subjectVm = Mapper.Map<SubjectVm>(subject);
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
      var student = DbContext.Users.OfType<Student>().FirstOrDefault(s => s.Id == attachDetachStudentToGroupVm.StudentId);

      if (student.GroupId == attachDetachStudentToGroupVm.GroupId)
      {
        student.GroupId = null;
        DbContext.Update(student);
        DbContext.SaveChanges();
      }


      var studentVm = Mapper.Map<StudentVm>(student);
      return studentVm;
    }
    catch (Exception ex)
    {
      Logger.LogError(ex, ex.Message);
      throw;
    }
  }

  public GroupVm DetachSubjectFromGroup(AttachDetachSubjectToGroupVm attachDetachSubjectToGroupVm)
  {
    try
    {
      var subjectGroup = DbContext.SubjectGroups.FirstOrDefault(g => g.GroupId == attachDetachSubjectToGroupVm.GroupId && g.SubjectId == attachDetachSubjectToGroupVm.SubjectId);
      if (subjectGroup != null)
      {
        DbContext.SubjectGroups.Remove(subjectGroup);
        DbContext.SaveChanges();
      }

      var group = DbContext.Groups.FirstOrDefault(g => g.Id == attachDetachSubjectToGroupVm.GroupId);
      var groupVm = Mapper.Map<GroupVm>(group);

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
      var subject = DbContext.Subjects.FirstOrDefault(s => s.Id == attachDetachSubjectToTeacherVm.SubjectId);

      subject.Teacher = null;
      subject.TeacherId = null;
      DbContext.Update(subject);
      DbContext.SaveChanges();

      var subjectVm = Mapper.Map<SubjectVm>(subject);
      return subjectVm;
    }
    catch (Exception ex)
    {
      Logger.LogError(ex, ex.Message);
      throw;
    }
  }

  public GroupVm GetGroup(Expression<Func<Group, bool>> filterPredicate)
  {
    try
    {
      if (filterPredicate == null)
        throw new ArgumentNullException("Filter is null");

      var group = DbContext.Groups.FirstOrDefault(filterPredicate);
      var groupVm = Mapper.Map<GroupVm>(group);
      return groupVm;
    }
    catch (Exception ex)
    {
      Logger.LogError(ex, ex.Message);
      throw;
    }
  }

  public IEnumerable<GroupVm> GetGroups(Expression<Func<Group, bool>> filterPredicate = null)
  {
    try
    {
      var groups = DbContext.Groups.AsQueryable();

      if (filterPredicate != null)
        groups = groups.Where(filterPredicate);

      var groupsVm = Mapper.Map<IEnumerable<GroupVm>>(groups);
      return groupsVm;
    }
    catch (Exception ex)
    {
      Logger.LogError(ex, ex.Message);
      throw;
    }
  }
}